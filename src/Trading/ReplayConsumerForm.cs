using Domain;
using Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Trading
{
    public partial class ReplayConsumerForm : Form
    {
        private List<DomainEvent> _events = new List<DomainEvent>();
        private Client _client;
        private readonly Color _origBackColor;

        public delegate void DomainEventReceived(DomainEventReceivedArgs e);
        private event DomainEventReceived _eventReceived;
        public event DomainEventReceived OnDomainEventReceived
        {
            add
            {
                _eventReceived += value;
            }
            remove
            {
                _eventReceived -= value;
            }
        }
        public ReplayConsumerForm()
        {
            InitializeComponent();
            _origBackColor = BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_Quit.Enabled = true;
            button_Close.Enabled = false;
            button_Consume.Enabled = false;
            _events.Clear();
            this.BackColor = Color.AliceBlue;
            _client = new Client();
            _client.OnDomainEventReceived += Client_OnDomainEventReceived;
            _client.Subscribe(Exchanges.Replay, Queues.YieldingReplay);
            _client.AutoDelete = true;
            _client.Connect();
            label_ConnectionStatus.Text = "Status: consuming";
        }

        private void Client_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                _events.Add(e.Event);
                label_EventStatus.Text = "Consumed events: " + _events.Count;
                Refresh();
            }));
            
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            if(_client != null)
            {
                _client.Dispose();
            }
            label_EventStatus.Text = "Applying events";
            _events = _events.OrderBy(x => x.TimeStamp).ToList();
            foreach(var evt in _events)
            {
                try
                {
                    _eventReceived?.Invoke(new DomainEventReceivedArgs(evt, default(ulong)));
                    Thread.Sleep(300);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            label_EventStatus.Text = "Events applied!";
            label_ConnectionStatus.Text = "Status: idle";
            BackColor = _origBackColor;
            button_Quit.Enabled = false;
            button_Close.Enabled = true;
            button_Consume.Enabled = true;
            Refresh();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
