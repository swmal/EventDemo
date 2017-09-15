using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class MessageReceivedArgs
    {
        public MessageReceivedArgs(ulong deliveryTag, byte[] body, string exchange)
        {
            Body = body;
            Exchange = exchange;
            DeliveryTag = deliveryTag;
        }

        public byte[] Body { get; private set; }

        public string Exchange { get; private set; }

        public ulong DeliveryTag { get; private set; }

        public DateTime TimeStamp { get; private set; }
    }
}
