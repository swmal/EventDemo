using Domain;
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

namespace EventLogger
{
    public partial class EventLoggerForm : Form
    {
        private ListViewHelper _eventListViewHelper;
        private Client _productClient;
        private Client _pricingClient;
        private Client _reservationClient;
        private Client _yieldClient;
        private ViewStore _viewStore;

        public EventLoggerForm()
        {
            InitializeComponent();
            label_Status.Visible = false;
            _viewStore = new ViewStore();
            _eventListViewHelper = new ListViewHelper(listView_Events);
            _productClient = new Client();
            _productClient.Subscribe(Exchanges.Products, Queues.EventLogger);
            _productClient.ExchangeType = ExchangeType.Topic;
            _productClient.SetRoutingKeys(
                ProductState.Sales.ToString(), 
                ProductState.Productify.ToString(), 
                ProductState.OffSale.ToString());
            _productClient.OnDomainEventReceived += _productClient_OnDomainEventReceived;
            _productClient.Connect();

            _pricingClient = new Client();
            _pricingClient.Subscribe(Exchanges.ProductPrice, Queues.EventLogger);
            _pricingClient.OnDomainEventReceived += _pricingClient_OnDomainEventReceived;
            _pricingClient.Connect();

            _reservationClient = new Client();
            _reservationClient.Subscribe(Exchanges.Bookings, Queues.EventLogger);
            _reservationClient.OnDomainEventReceived += _reservationClient_OnDomainEventReceived;
            _reservationClient.Connect();

            _yieldClient = new Client();
            _yieldClient.Subscribe(Exchanges.YieldAdjustment, Queues.EventLogger);
            _yieldClient.OnDomainEventReceived += _yieldClient_OnDomainEventReceived;
            _yieldClient.Connect();
        }

        private void _yieldClient_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            UpdateDomainEvent(e.Event);
        }

        private void _reservationClient_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            UpdateDomainEvent(e.Event);
        }

        private void _pricingClient_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            UpdateDomainEvent(e.Event);
        }

        private void _productClient_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            UpdateDomainEvent(e.Event);
        }

        private void UpdateDomainEvent(DomainEvent e)
        {
            Invoke(new MethodInvoker(delegate () {
                _viewStore.Add(e);
                _eventListViewHelper.Bind(_viewStore.GetStore<DomainEvent>().OrderByDescending(x => x.TimeStamp),
                    x => new string[] 
                    {
                        x.Id.ToString(),
                        x.TimeStamp.ToString("hh:mm:ss"),
                        x.Exchange,
                        x.RoutingKey
                    });

                listView_Events.Refresh();
            }));
            
        }

        private void listView_Events_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView_Events_DoubleClick(object sender, EventArgs e)
        {
            var ix = listView_Events.SelectedIndices[0];
            var eventViewer = new EventViewer(_viewStore.GetStore<DomainEvent>().OrderByDescending(x => x.TimeStamp).ElementAt(ix));
            eventViewer.Show();
        }

        private void button_CloseAbort_Click(object sender, EventArgs e)
        {
            _productClient.Dispose();
            _pricingClient.Dispose();
            _reservationClient.Dispose();
            _yieldClient.Dispose();
            Close();
        }

        private void button_Replay_Click(object sender, EventArgs e)
        {
            var client = new Client();
            foreach (var evt in _viewStore.GetStore<DomainEvent>().OrderBy(x => x.TimeStamp))
            {
                client.Publish(Exchanges.Replay, evt.ToBytes());
            }
            label_Status.Visible = true;
            label_Status.Text = "All events replayed!";
            Refresh();
            Thread.Sleep(3000);
            label_Status.Visible = false;
        }
    }
}
