using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using Domain;

namespace Messaging
{
    class MyBasicConsumer : IBasicConsumer
    {
        public delegate void MessageReceived(MessageReceivedArgs e);
        private event MessageReceived _messageReceived;
        public event MessageReceived OnMessageReceived
        {
            add
            {
                _messageReceived += value;
            }
            remove
            {
                _messageReceived -= value;
            }
        }

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

        public IModel Model => throw new NotImplementedException();

        public event EventHandler<ConsumerEventArgs> ConsumerCancelled;

        public void HandleBasicCancel(string consumerTag)
        {
            throw new NotImplementedException();
        }

        public void HandleBasicCancelOk(string consumerTag)
        {
            //throw new NotImplementedException();
        }

        public void HandleBasicConsumeOk(string consumerTag)
        {
            //throw new NotImplementedException();
        }

        public void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            var evt = DomainEvent.FromBytes(body);
            var evtArgs = new DomainEventReceivedArgs(evt, deliveryTag);
            _eventReceived?.Invoke(evtArgs);
            var args = new MessageReceivedArgs(deliveryTag, evt.Data, exchange);
            _messageReceived?.Invoke(args);
        }

        public void HandleModelShutdown(object model, ShutdownEventArgs reason)
        {
            //throw new NotImplementedException();
        }
    }
}
