using Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public abstract class AggregateRoot
    {
        public string Id { get; set; }

        internal abstract string GetPrefix();
    }
}
