using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class DomainEvent
    {
        public DomainEvent() { }

        public DomainEvent(byte[] data)
            : this(data, false)
        {
            
        }

        public byte[] ToBytes()
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, this);
                return ms.ToArray();
            }
        }
        public DomainEvent(byte[] data, bool isPartOfReplay)
        {
            Data = data;
            TimeStamp = DateTime.Now;
            IsPartOfReplay = isPartOfReplay;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public byte[] Data { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool IsPartOfReplay { get; set; }

        public string Exchange { get; set; }

        public string ExchangeType { get; set; }

        public string RoutingKey { get; set; }

        public static DomainEvent FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return (DomainEvent)new BinaryFormatter().Deserialize(ms);
            }
        }
    }
}
