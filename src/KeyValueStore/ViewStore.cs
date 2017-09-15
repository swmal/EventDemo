using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueStore
{
    public class ViewStore
    {
        private readonly Dictionary<Type, List<object>> _store;

        public ViewStore()
        {
            _store = new Dictionary<Type, List<object>>();
        }

        public void Add<T>(T item)
        {
            if(!_store.ContainsKey(typeof(T)))
            {
                _store.Add(typeof(T), new List<object>());
            }
            _store[typeof(T)].Add(item);
        }

        public bool Remove<T>(T item)
        {
            if (!_store.ContainsKey(typeof(T))) return false;
            return _store[typeof(T)].Remove(item);
        }

        public void Clear<T>()
        {
            if (!_store.ContainsKey(typeof(T))) return;
            _store[typeof(T)].Clear();
        }

        public void Update<T>(Func<T, bool> match, Action<T> updateAction)
        {
            var item = _store[typeof(T)]
                .Select(x => (T)x)
                .Where(match)
                .FirstOrDefault();
            updateAction(item);
        }

        public IEnumerable<T> GetStore<T>()
        {
            if (!_store.ContainsKey(typeof(T))) return Enumerable.Empty<T>();
            return _store[typeof(T)].Select(x => (T)x);
        }

        public int Count<T>()
        {
            return GetStore<T>().Count();
        }

        public T Get<T>(int index)
        {
            return GetStore<T>().ElementAt(index);
        }
    }
}
