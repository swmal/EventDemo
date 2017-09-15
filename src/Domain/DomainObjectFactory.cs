using Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class DomainObjectFactory
    {
        public static T Create<T>()
            where T : AggregateRoot,new()
        {
            var aggregateRoot = new T();
            aggregateRoot.Id = aggregateRoot.GetPrefix() + IdentityManager.Next();
            return aggregateRoot;
        }

        public static T FromBytes<T>(byte[] bytes)
            where T : AggregateRoot
        {
            using (var ms = new MemoryStream(bytes))
            {
                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }
    }
}
