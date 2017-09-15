using Domain;
using Domain.DomainServices;
using KeyValueStore;
using Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trading.Views;
using UiComponents;

namespace Trading
{
    public partial class TradingForm : Form
    {
        private readonly Client _productClient;
        private readonly Client _pricingClient;
        private readonly Client _bookingClient;
        private readonly ListViewHelper _tradingListViewHelper;
        private readonly ViewStore _viewStore;
        private readonly Color _originalBackcolor;
        private readonly YieldCalculator _yieldCalculator;
        private bool _replaying = false;
        public TradingForm()
        {
            InitializeComponent();
            _productClient = new Client();
            _productClient.Subscribe(Exchanges.Products, Queues.TradingProducts);
            _productClient.SetRoutingKeys(
                ProductState.Sales.ToString(), 
                ProductState.Productify.ToString(), 
                ProductState.OffSale.ToString());
            _productClient.OnMessageReceived += _productClient_OnMessageReceived;
            _productClient.ExchangeType = ExchangeType.Topic;
            _productClient.Connect();

            _pricingClient = new Client();
            _pricingClient.Subscribe(Exchanges.ProductPrice, Queues.TradingPricing);
            _pricingClient.OnMessageReceived += _pricingClient_OnMessageReceived;
            _pricingClient.Connect();

            _bookingClient = new Client();
            _bookingClient.Subscribe(Exchanges.Bookings, Queues.TradingBooking);
            _bookingClient.OnMessageReceived += _bookingClient_OnMessageReceived;
            _bookingClient.Connect();

            _tradingListViewHelper = new ListViewHelper(listView_Inventory);
            _viewStore = new ViewStore();
            _originalBackcolor = BackColor;
            _yieldCalculator = new YieldCalculator();

        }

        private void _bookingClient_OnMessageReceived(MessageReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (e.Exchange == Exchanges.Bookings)
                {
                    var booking = DomainObjectFactory.FromBytes<Booking>(e.Body);
                    UpdateBooking(booking);
                }
                MessageReceived();
            }));
        }

        private void _pricingClient_OnMessageReceived(MessageReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (e.Exchange == Exchanges.ProductPrice)
                {
                    var product = DomainObjectFactory.FromBytes<ProductPrice>(e.Body);
                    UpdatePricing(product);
                }
                MessageReceived();
            }));
        }

        private void _productClient_OnMessageReceived(MessageReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (e.Exchange == Exchanges.Products)
                {
                    var product = DomainObjectFactory.FromBytes<Product>(e.Body);
                    UpdateProduct(product);
                }
                MessageReceived();
            }));
        }

        private string GetPriceKey(string productId)
        {
            return "price" + productId;
        }

        private string GetNoBookingsKey(string productId)
        {
            return "nobookings" + productId;
        }

        private void UpdateProduct(Product product)
        {
            var item = _viewStore.GetStore<TradingItem>()
                .FirstOrDefault(x => x.ProductId == product.Id);
            if (item != null)
            {
                item.ProductId = product.Id;
                item.Name = product.Name;
                item.State = product.State;
                item.Allotment = product.Allotment;
            }
            else
            {
                var viewModel = new TradingItem()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    State = product.State,
                    Allotment = product.Allotment,
                    LastAction = TradingActionType.OnSale
                };
                // check for previous events
                if(Storage.ContainsKey(GetPriceKey(product.Id)))
                {
                    var price = Storage.Get<ProductPrice>(GetPriceKey(product.Id));
                    viewModel.Price = price.Price;
                    viewModel.Cost = price.Cost;
                }

                var bookingKey = GetNoBookingsKey(product.Id);
                if (Storage.ContainsKey(bookingKey))
                {
                    var nBookings = Storage.Get<int>(bookingKey);
                    viewModel.NoBookings = nBookings;
                }

                _viewStore.Add(viewModel);
                Storage.Store(product.Id, viewModel);
            }
            _tradingListViewHelper.Clear();
            BindTradingItems();

            listView_Inventory.Refresh();
        }

        private void UpdatePricing(ProductPrice price)
        {
            Storage.Store(GetPriceKey(price.ProductId), price);
            var item = _viewStore.GetStore<TradingItem>()
                            .FirstOrDefault(x => x.ProductId == price.ProductId);
            if (item != null)
            {
                _viewStore.Update<TradingItem>(x => x.ProductId == price.ProductId, y => 
                {
                    y.InitialPrice = price.Price;
                    y.Price = price.Price;
                    y.Cost = price.Cost;
                });
            }
            BindTradingItems();
        }

        private void UpdateBooking(Booking booking)
        {
            var item = _viewStore.GetStore<TradingItem>()
                            .FirstOrDefault(x => x.ProductId == booking.ProductId);
            if (item != null)
            {
                _viewStore.Update<TradingItem>(x => x.ProductId == booking.ProductId, y => y.NoBookings += 1);
                // calculate yield adjustment
                var adjustment = _yieldCalculator.CaluclateYieldAdjustment(item.Cost, item.Price, item.NoBookings, item.Allotment);
                var yieldAdjustment = DomainObjectFactory.Create<YieldAdjustment>();
                yieldAdjustment.Adjustment = Convert.ToInt32(adjustment);
                yieldAdjustment.ProductId = booking.ProductId;
                Storage.Store(yieldAdjustment.Id, yieldAdjustment);
                _viewStore.Update<TradingItem>(
                    x => x.ProductId == booking.ProductId,
                    y =>
                    {
                        y.YieldAdjustment = yieldAdjustment.Adjustment;
                        y.Price += yieldAdjustment.Adjustment;
                    });
                if(!_replaying)
                {
                    var client = new Client();
                    client.Publish(Exchanges.YieldAdjustment, yieldAdjustment.ToBytes());
                }
                MessageSent();
            }
            else
            {
                var key = GetNoBookingsKey(booking.ProductId);
                var nBookings = Storage.ContainsKey(key) ? Storage.Get<int>(key) : 0;
                Storage.Store(key, ++nBookings);
            }
            BindTradingItems();
        }

        private void MessageReceived()
        {
            panel_MessageReceived.BackColor = Color.Green;
            Refresh();
            Thread.Sleep(500);
            panel_MessageReceived.BackColor = _originalBackcolor;
            Refresh();
        }

        private void MessageSent()
        {
            panel_EventPublished.BackColor = Color.Orange;
            Refresh();
            Thread.Sleep(500);
            panel_EventPublished.BackColor = _originalBackcolor;
            Refresh();
        }

        private void BindTradingItems()
        {
            _tradingListViewHelper.Bind(
                _viewStore.GetStore<TradingItem>(), 
                x => new string[] 
                {
                    x.ProductId.ToString(),
                    x.Name, x.NoBookings.ToString(),
                    x.State.ToString(),
                    x.Cost.ToString(),
                    x.InitialPrice.ToString(),
                    x.Price.ToString(),
                    x.Allotment.ToString(),
                    x.YieldAdjustment.ToString()
                    
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productClient.Dispose();
            _pricingClient.Dispose();
            _bookingClient.Dispose();
            this.Close();
        }

        private void button_Replay_Click(object sender, EventArgs e)
        {
            var replayForm = new ReplayConsumerForm();
            replayForm.OnDomainEventReceived += ReplayForm_OnDomainEventReceived;
            replayForm.Show(this);
        }

        private void ReplayForm_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            _replaying = true;
            var evt = DomainEvent.FromBytes(e.Event.Data);
            switch(evt.Exchange)
            {
                case Exchanges.Products:
                    UpdateProduct(DomainObjectFactory.FromBytes<Product>(evt.Data));
                    break;
                case Exchanges.ProductPrice:
                    UpdatePricing(DomainObjectFactory.FromBytes<ProductPrice>(evt.Data));
                    break;
                case Exchanges.Bookings:
                    UpdateBooking(DomainObjectFactory.FromBytes<Booking>(evt.Data));
                    break;
            }
            _replaying = false;
            BindTradingItems();
            Refresh();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            _viewStore.Clear<TradingItem>();
            this.listView_Inventory.Items.Clear();
            BindTradingItems();
        }

        private void listView_Inventory_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip_Options.Show(Cursor.Position);
                var ix = listView_Inventory.SelectedIndices[0];
                var item = _viewStore.GetStore<TradingItem>().ElementAt(ix);
                takeOffSaleToolStripMenuItem.Enabled = (item.LastAction == TradingActionType.OnSale);
                takeOnSaleToolStripMenuItem.Enabled = (item.LastAction == TradingActionType.OffSale);
            }
        }

        private void takeOffSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ix = listView_Inventory.SelectedIndices[0];
            var item = _viewStore.GetStore<TradingItem>().ElementAt(ix);
            var action = DomainObjectFactory.Create<TradingAction>();
            item.LastAction = TradingActionType.OffSale;
            action.Action = TradingActionType.OffSale;
            action.ProductId = item.ProductId;
            var client = new Client();
            client.Publish(Exchanges.ProductsTrading, action.ToBytes());
        }

        private void takeOnSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ix = listView_Inventory.SelectedIndices[0];
            var item = _viewStore.GetStore<TradingItem>().ElementAt(ix);
            var action = DomainObjectFactory.Create<TradingAction>();
            item.LastAction = TradingActionType.OnSale;
            action.Action = TradingActionType.OnSale;
            action.ProductId = item.ProductId;
            var client = new Client();
            client.Publish(Exchanges.ProductsTrading, action.ToBytes());
        }
    }
}
