using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueStore
{
    public abstract class ViewBase
    {
        public ViewBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
