using Domain;
using KeyValueStore;
using Messaging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductLifecycleManager
{
    public partial class PlmForm : Form
    {
        public PlmForm()
        {
            InitializeComponent();
            this.textBox_Name.Focus();
        }

        internal bool _updateState;
        internal string _currentId;
        
        private void Publish(Product product)
        {
            var client = new Client();
            client.ExchangeType = Messaging.ExchangeType.Topic;
            client.Publish(Exchanges.Products, product.State.ToString(), product.ToBytes());
        }


        private void button_Close_Click(object sender, EventArgs e)
        {
            // clean up code here
            this.Close();
        }

        private void ClearFields()
        {
            textBox_Name.Text = string.Empty;
            comboBox_State.Text = ProductState.Draft.ToString();
            button_Create.Text = "Create";
            _updateState = false;
        }

        private void SetFields(Product product)
        {
            textBox_Name.Text = product.Name;
            comboBox_State.SelectedText = product.State.ToString();
            button_Create.Text = "Update";
            _updateState = true;
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox_Name.Text))
            {
                MessageBox.Show("Name missing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var product = _updateState ? Storage.Get(_currentId) as Product : DomainObjectFactory.Create<Product>();
            product.Name = textBox_Name.Text;
            //TODO: set allotment
            product.Allotment = 9;
            var state = ProductState.Draft;
            if(Enum.TryParse(comboBox_State.Text, out state))
            {
                product.State = state;
            }
            Storage.Store(product.Id, product);
            if(!_updateState)
            {
                var item = new ListViewItem(new string[3] { product.Id.ToString(), product.Name.ToString(), product.State.ToString() });
                listView_Products.Items.Add(item);
            }
            else
            {
                listView_Products.Items.RemoveAt(listView_Products.SelectedIndices[0]);
                var item = new ListViewItem(new string[3] { product.Id.ToString(), product.Name.ToString(), product.State.ToString() });
                listView_Products.Items.Add(item);
            }
            Publish(product);
            ClearFields();
            listView_Products.Refresh();
        }

        private void listView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Products.SelectedIndices.Count == 0) return;
            var ix = listView_Products.SelectedIndices[0];
            var id = listView_Products.Items[ix].Text;
            var product = Storage.Get(id) as Product;
            _currentId = id;
            SetFields(product);
        }
    }
}
