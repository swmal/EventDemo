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
    public class TradingAction : AggregateRoot
    {
        public string ProductId { get; set; }

        public TradingActionType Action { get; set; }

        public byte[] ToBytes()
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, this);
                return ms.ToArray();
            }
        }

        internal override string GetPrefix()
        {
            return "TA";
        }
    }
}
