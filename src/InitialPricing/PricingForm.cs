using Domain;
using Domain.DomainServices;
using InitialPricing.Views;
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
using UiComponents;

namespace InitialPricing
{
    public partial class PricingForm : Form
    {
        private readonly Client _queueClient;
        private readonly ListViewHelper _listViewHelper;
        private readonly ViewStore _viewStore = new ViewStore();
        private string _currentId;
        private readonly CostCalculator _costCalculator;
        public PricingForm()
        {
            InitializeComponent();
            textBox_Price.Enabled = false;
            _queueClient = new Client();
            _queueClient.Subscribe(Exchanges.Products, Queues.InitialPricing);
            _queueClient.ExchangeType = ExchangeType.Topic;
            _queueClient.SetRoutingKeys(
                ProductState.Sales.ToString(), 
                ProductState.Productify.ToString());
            _queueClient.OnMessageReceived += _queueClient_OnMessageReceived;
            _queueClient.Connect();
            _listViewHelper = new ListViewHelper(listView_Products);
            _costCalculator = new CostCalculator();
        }

        private void DoWork(object target, DoWorkEventArgs e)
        {
            var window = (PricingForm)e.Argument;
            var originalColor = window.BackColor;
            window.BackColor = Color.Green;
            Thread.Sleep(500);
            window.BackColor = originalColor;
        }

        private void _queueClient_OnMessageReceived(MessageReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (e.Exchange == Exchanges.Products)
                {
                    var product = DomainObjectFactory.FromBytes<Product>(e.Body);
                    UpdateStore(product);
                }
                MessageReceived();
            }));  
        }

        private void UpdateStore(Product product)
        {
            var item = _viewStore.GetStore<InitialPricingView>()
                .FirstOrDefault(x => x.ProductId == product.Id);
            if (item != null)
            {
                item.State = product.State;
                item.Name = product.Name;
            }
            else
            {
                var viewModel = new InitialPricingView()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    State = product.State
                };
                _viewStore.Add(viewModel);
                Storage.Store(product.Id, viewModel);
            }
            _listViewHelper.Clear();
            _listViewHelper.Bind(_viewStore.GetStore<InitialPricingView>(), x => new string[] { x.ProductId.ToString(), x.Name, x.State.ToString(), x.Price.ToString() });

            listView_Products.Refresh();
        }

        private void SetFields(InitialPricingView view)
        {
            label_Product.Text = view.Name;
            label_State.Text = view.State.ToString();
            textBox_Price.Text = view.Price > 0 ? view.Price.ToString() : string.Empty;
            textBox_Price.Enabled = true;
        }

        private void ClearFields()
        {
            label_Product.Text = string.Empty;
            label_State.Text = string.Empty;
            textBox_Price.Text = string.Empty;
            textBox_Price.Enabled = false;
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
            _queueClient.Dispose();
            this.Close();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Price.Text))
            {
                MessageBox.Show("Price missing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var pricingView = Storage.Get(_currentId) as InitialPricingView;
            pricingView.Price = int.Parse(textBox_Price.Text);
            Storage.Store(_currentId, pricingView);
            var productPrice = DomainObjectFactory.Create<ProductPrice>();
            productPrice.ProductId = _currentId;
            productPrice.Price = pricingView.Price;
            productPrice.Cost = _costCalculator.Calculate(pricingView.Price);
            var client = new Client();
            client.Publish(Exchanges.ProductPrice, productPrice.ToBytes());
            
            ClearFields();
            var listViewHelper = new ListViewHelper(listView_Products);
            _viewStore.Update<InitialPricingView>(x => x.ProductId == _currentId, p => p.Price = pricingView.Price);
            listViewHelper.Bind(_viewStore.GetStore<InitialPricingView>(), x => new string[] { x.ProductId.ToString(), x.Name, x.State.ToString(), x.Price.ToString() });
            listView_Products.Refresh();
        }

        private void listView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Products.SelectedIndices.Count == 0) return;
            var ix = listView_Products.SelectedIndices[0];
            var productId = listView_Products.Items[ix].Text;
            var view = Storage.Get(productId) as InitialPricingView;
            _currentId = productId;
            SetFields(view);
        }

        private void listView_Inventory_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
