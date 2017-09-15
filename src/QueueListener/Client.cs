using Domain;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging
{
    public class Client : IDisposable
    {
        private readonly string _host;
        private readonly string _virtualHost;
        private string _exchange;
        private string _queue;
        private string[] _routingKeys;
        private IModel _model;
        private Thread _thread;
        private bool _running = false;
        private string _user = "eventdemo";
        private string _pwd = "eventdemo";

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

        public Client()
            : this("localhost", "eventdemo")
        { }

        public Client(string host, string virtualHost)
        {
            _host = host;
            _virtualHost = virtualHost;
            ExchangeType = ExchangeType.Fanout;
            AutoDelete = false;
            _routingKeys = new string[0];
        }

        public void Subscribe(string exchange, string queue)
        {
            _exchange = exchange;
            _queue = queue;
        }

        public ExchangeType ExchangeType{ get; set; }

        public bool AutoDelete { get; set; }

        public void SetRoutingKeys(params string[] routingKeys)
        {
            _routingKeys = routingKeys;
        }

        public void Connect()
        {
            var ts = new ThreadStart(StartListening);
            _thread = new Thread(ts);
            _running = true;
            _thread.Start();
        }

        private void StartListening()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _host,
                UserName = _user,
                Password = _pwd,
                VirtualHost = _virtualHost
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (_model = connection.CreateModel())
                {
                    _model.ExchangeDeclare(_exchange, ExchangeType.Value, true, false, null);
                    var properties = _model.CreateBasicProperties();
                    properties.Type = "binary";
                    
                    _model.QueueDeclare(_queue, AutoDelete? false : true, false, AutoDelete, null);
                    if(_routingKeys.Length == 0)
                    {
                        _model.QueueBind(_queue, _exchange, string.Empty, null);
                    }
                    else
                    {
                        foreach(var routingKey in _routingKeys)
                        {
                            _model.QueueBind(_queue, _exchange, routingKey, null);
                        }
                    }
                    

                    var consumer = new MyBasicConsumer();
                    consumer.OnMessageReceived += Consumer_OnMessageReceived;
                    consumer.OnDomainEventReceived += Consumer_OnDomainEventReceived;
                    while(_running)
                    {
                        _model.BasicConsume(_queue, true, consumer);
                        Thread.Sleep(1000);
                    }
                    
                   
                }
            }
        }

        private void Consumer_OnDomainEventReceived(DomainEventReceivedArgs e)
        {
            _eventReceived?.Invoke(e);
            //_model.BasicAck(e.DeliveryTag, false);
        }

        private void Consumer_OnMessageReceived(MessageReceivedArgs e)
        {
            _messageReceived?.Invoke(e);
            //_model.BasicAck(e.DeliveryTag, false);
        }

        public void Dispose()
        {
            _running = false;
            if(_model != null)
            {
                _model.Abort();
            }
            if (_thread.ThreadState == ThreadState.Running) _thread.Abort();
        }

        public void Publish(string exchange, string routingKey, byte[] data)
        {
            var evt = new DomainEvent(data)
            {
                Exchange = exchange,
                ExchangeType = ExchangeType.Value,
                RoutingKey = routingKey
            };
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _host,
                UserName = _user,
                Password = _pwd,
                VirtualHost = _virtualHost
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    model.ExchangeDeclare(exchange, ExchangeType.Value, true, false, null);
                    var properties = model.CreateBasicProperties();
                    properties.Type = "binary";
                    model.BasicPublish(exchange, routingKey, null, evt.ToBytes());
                }
            }
        }

        public void Publish(string exchange, byte[] data)
        {
            Publish(exchange, string.Empty, data);
        }

        public void ClearQueue(string queue)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _host,
                UserName = _user,
                Password = _pwd,
                VirtualHost = _virtualHost
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (_model = connection.CreateModel())
                {
                    _model.QueuePurge(queue);
                }
            }
        }
    }
}
