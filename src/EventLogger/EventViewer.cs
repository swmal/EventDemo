using Domain;
using Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EventLogger
{
    public partial class EventViewer : Form
    {
        public EventViewer(DomainEvent evt)
        {
            InitializeComponent();
            _event = evt;
            InitEventViewer();
        }

        private DomainEvent _event;

        public void InitEventViewer()
        {
            var content = string.Empty;
            switch(_event.Exchange)
            {
                case Exchanges.Products:
                    content = new DomainEventSerializable<Product>(_event.Exchange, _event.Data)
                    {
                        Id = _event.Id,
                        Exchange = _event.Exchange,
                        ExchangeType = _event.ExchangeType,
                        IsPartOfReplay = _event.IsPartOfReplay,
                        RoutingKey = _event.RoutingKey,
                        TimeStamp = _event.TimeStamp
                    }.ToString();
                    break;
                case Exchanges.ProductPrice:
                    content = new DomainEventSerializable<ProductPrice>(_event.Exchange, _event.Data)
                    {
                        Id = _event.Id,
                        Exchange = _event.Exchange,
                        ExchangeType = _event.ExchangeType,
                        IsPartOfReplay = _event.IsPartOfReplay,
                        RoutingKey = _event.RoutingKey,
                        TimeStamp = _event.TimeStamp
                    }.ToString();
                    break;
                case Exchanges.Bookings:
                    content = new DomainEventSerializable<Booking>(_event.Exchange, _event.Data)
                    {
                        Id = _event.Id,
                        Exchange = _event.Exchange,
                        ExchangeType = _event.ExchangeType,
                        IsPartOfReplay = _event.IsPartOfReplay,
                        RoutingKey = _event.RoutingKey,
                        TimeStamp = _event.TimeStamp
                    }.ToString();
                    break;
                case Exchanges.YieldAdjustment:
                    content = new DomainEventSerializable<YieldAdjustment>(_event.Exchange, _event.Data)
                    {
                        Id = _event.Id,
                        Exchange = _event.Exchange,
                        ExchangeType = _event.ExchangeType,
                        IsPartOfReplay = _event.IsPartOfReplay,
                        RoutingKey = _event.RoutingKey,
                        TimeStamp = _event.TimeStamp
                    }.ToString();
                    break;
            }          
            
            this.textBox_Payload.Text = content;   
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
