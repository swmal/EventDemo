using Domain;
using Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EventLogger
{
    [XmlInclude(typeof(Product))]
    [XmlInclude(typeof(ProductPrice))]
    [XmlInclude(typeof(Booking))]
    [XmlInclude(typeof(YieldAdjustment))]
    [XmlRoot(ElementName = "DomainEvent")]
    [Serializable]
    public class DomainEventSerializable<T>
    {
        public DomainEventSerializable()
        {

        }

        public DomainEventSerializable(string exchange, byte[] data)
        {
            Initialize(exchange, data);
        }
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public bool IsPartOfReplay { get; set; }

        public string Exchange { get; set; }

        public string ExchangeType { get; set; }

        public string RoutingKey { get; set; }

        public T Data { get; set; }

        public void Initialize(string exchange, byte[] data)
        {
            object obj = null;
            using (var ms = new MemoryStream(data))
            {
                obj = new BinaryFormatter().Deserialize(ms);
            }
            switch (exchange)
            {
                case Exchanges.Products:
                    Data = (T)obj;
                    break;
                case Exchanges.ProductPrice:
                    Data = (T)obj;
                    break;
                case Exchanges.Bookings:
                    Data = (T)obj;
                    break;
                case Exchanges.YieldAdjustment:
                    Data = (T)obj;
                    break;
                default:
                    return;
            }
        }

        public override string ToString()
        {
            var serializer = new XmlSerializer(this.GetType());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
        }
    }
}
