using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Domain
{
    [Serializable]
    public class Product : AggregateRoot
    {
        public string Name { get; set; }

        public ProductState State { get; set; }

        public int Allotment { get; set; }

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
            return "P";
        }
    }
}
