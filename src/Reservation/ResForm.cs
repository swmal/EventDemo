using Domain;
using KeyValueStore;
using Messaging;
using Reservation.Views;
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
using UiComponents;

namespace Reservation
{
    public partial class ResForm : Form
    {
        private readonly Client _productClient;
        private readonly Client _pricingClient;
        private readonly Client _yieldClient;
        private readonly Client _tradingClient;
        private readonly ListViewHelper _inventoryListViewHelper;
        private readonly ListViewHelper _bookingListViewHelper;
        private readonly ViewStore _viewStore = new ViewStore();
        private readonly Dictionary<string, ProductPrice> _productPrices = new Dictionary<string, ProductPrice>();
        private int _currentId;
        public ResForm()
        {
            InitializeComponent();
            _productClient = new Client();
            _productClient.Subscribe(Exchanges.Products, Queues.ReservationProducts);
            _productClient.SetRoutingKeys(ProductState.Sales.ToString(), ProductState.OffSale.ToString());
            _productClient.ExchangeType = ExchangeType.Topic;
            _productClient.OnMessageReceived += _productClient_OnMessageReceived;
            _productClient.Connect();

            _inventoryListViewHelper = new ListViewHelper(listView_Inventory);
            _pricingClient = new Client();
            _pricingClient.Subscribe(Exchanges.ProductPrice, Queues.ReservationPricing);
            _pricingClient.OnMessageReceived += _pricingClient_OnMessageReceived;
            _pricingClient.Connect();

            _yieldClient = new Client();
            _yieldClient.Subscribe(Exchanges.YieldAdjustment, Queues.ReservationYield);
            _yieldClient.OnMessageReceived += _yieldClient_OnMessageReceived;
            _yieldClient.Connect();

            _tradingClient = new Client();
            _tradingClient.Subscribe(Exchanges.ProductsTrading, Queues.ReservationTrading);
            _tradingClient.OnMessageReceived += _tradingClient_OnMessageReceived;
            _tradingClient.Connect();
            _bookingListViewHelper = new ListViewHelper(listView_Bookings);
        }

        private void _tradingClient_OnMessageReceived(MessageReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (e.Exchange == Exchanges.ProductsTrading)
                {
                    var action = DomainObjectFactory.FromBytes<TradingAction>(e.Body);
                    UpdateTrading(action);
                }
                MessageReceived();
            }));
        }

        private void _yieldClient_OnMessageReceived(MessageReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (e.Exchange == Exchanges.YieldAdjustment)
                {
                    var price = DomainObjectFactory.FromBytes<YieldAdjustment>(e.Body);
                    UpdateYield(price);
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
                    var price = DomainObjectFactory.FromBytes<ProductPrice>(e.Body);
                    UpdatePricing(price);
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

        private void UpdateTrading(TradingAction action)
        {
            var item = _viewStore.GetStore<InventoryItem>()
                .FirstOrDefault(x => x.ProductId == action.ProductId);
            if(item != null)
            {
                item.TradingState = action.Action;
            }
            BindInventoryList();
            Refresh();
        }

        private void UpdateProduct(Product product)
        {
            Storage.Store(product.Id, product);
            var item = _viewStore.GetStore<InventoryItem>()
                .FirstOrDefault(x => x.ProductId == product.Id);
            if (item != null)
            {
                item.Name = product.Name;
                item.Allotment = product.Allotment;
                if(_productPrices.ContainsKey(product.Id))
                {
                    item.Price = _productPrices[product.Id].Price;
                }
            }
            else
            {
                var viewModel = new InventoryItem()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Allotment = product.Allotment,
                    TradingState = TradingActionType.OnSale
                };
                if (_productPrices.ContainsKey(product.Id))
                {
                    viewModel.Price = _productPrices[product.Id].Price;
                }
                _viewStore.Add(viewModel);
            }
            _inventoryListViewHelper.Clear();
            BindInventoryList();

            listView_Inventory.Refresh();
        }

        private void UpdatePricing(ProductPrice price)
        {
            Storage.Store(price.Id, price);
            if(_productPrices.ContainsKey(price.ProductId))
            {
                _productPrices.Remove(price.ProductId);
            }
            _productPrices.Add(price.ProductId, price);
            var item = _viewStore.GetStore<InventoryItem>()
                            .FirstOrDefault(x => x.ProductId == price.ProductId);
            if(item != null)
            {
                _viewStore.Update<InventoryItem>(x => x.ProductId == price.ProductId, y => y.Price = price.Price);
            }
            BindInventoryList();
        }

        private void UpdateYield(YieldAdjustment adjustment)
        {
            var item = _viewStore.GetStore<InventoryItem>()
                            .FirstOrDefault(x => x.ProductId == adjustment.ProductId);
            if (item != null)
            {
                _viewStore.Update<InventoryItem>(x => x.ProductId == adjustment.ProductId, y => y.Price += adjustment.Adjustment);
            }
            BindInventoryList();
        }

        private void BindInventoryList()
        {
            _inventoryListViewHelper.Bind(
                _viewStore.GetStore<InventoryItem>()
                .Where(x => 
                    Storage.Get<Product>(x.ProductId).State == ProductState.Sales 
                    && x.Price > 0 
                    && x.TradingState == TradingActionType.OnSale)    
                .OrderByDescending(x => x.ProductId), 
                x => new string[] 
                {
                    x.ProductId.ToString(),
                    x.Name, x.Allotment.ToString(),
                    x.Price.ToString()
                });
        }

        private void BindBookings()
        {
            _bookingListViewHelper.Bind(
                _viewStore
                .GetStore<BookingItem>()
                .OrderByDescending(x => x.BookingNumber), 
                x => new string[] 
                {
                    x.BookingNumber.ToString(),
                    x.ProductName,
                    x.Price.ToString()
                });
        }

        private void MessageReceived()
        {
            var color = panel_MessageReceived.BackColor;
            panel_MessageReceived.BackColor = Color.Green;
            Refresh();
            Thread.Sleep(500);
            panel_MessageReceived.BackColor = color;
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pricingClient.Dispose();
            _productClient.Dispose();
            this.Close();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            
        }

        private void listView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView_Inventory_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip_Book.Show(Cursor.Position);
            }
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ix = listView_Inventory.SelectedIndices[0];
            var item = _viewStore
                .GetStore<InventoryItem>()
                .OrderByDescending(x => x.ProductId)
                .ElementAt(ix);
            var booking = DomainObjectFactory.Create<Booking>();
            booking.ProductId = item.ProductId;
            booking.Price = item.Price;
            _viewStore.Update<InventoryItem>(x => x.ProductId == item.ProductId, y => y.Allotment -= 1);
            BindInventoryList();

            var client = new Client();
            client.Publish(Exchanges.Bookings, booking.ToBytes());

            // add booking to list view
            var product = Storage.Get(item.ProductId) as Product;
            var bookingItem = new BookingItem
            {
                BookingNumber = booking.Id,
                Price = booking.Price,
                ProductName = product.Name
            };
            _viewStore.Add(bookingItem);
            BindBookings();
        }
    }
}
