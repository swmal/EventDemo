using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueStore
{
    public static class Storage
    {
        private static Dictionary<object, object> _store = new Dictionary<object, object>();

        public static void Store(object key, object value)
        {
            if (_store.ContainsKey(key)) _store.Remove(key);
            _store.Add(key, value);
        }

        public static bool ContainsKey(object key)
        {
            return _store.ContainsKey(key);
        }

        public static object Get(object key)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (!_store.ContainsKey(key)) throw new InvalidOperationException("Key not present");
            return _store[key];
        }

        public static T Get<T>(object key)
        {
            var obj = Get(key);
            return obj == null ? default(T) : (T)obj;
        }
    }
}
