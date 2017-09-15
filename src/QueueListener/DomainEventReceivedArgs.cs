using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class DomainEventReceivedArgs
    {
        public DomainEventReceivedArgs(DomainEvent e, ulong deliveryTag)
        {
            Event = e;
            DeliveryTag = deliveryTag;
        }

        public DomainEvent Event { get; set; }

        public ulong DeliveryTag { get; private set; }
    }
}
