using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class ExchangeType
    {
        private ExchangeType(string val)
        {
            Value = val;
        }

        public string Value { get; private set; }

        public static ExchangeType Fanout
        {
            get { return new ExchangeType("fanout"); }
        }

        public static ExchangeType Topic
        {
            get { return new ExchangeType("topic"); }
        }
    }
}
