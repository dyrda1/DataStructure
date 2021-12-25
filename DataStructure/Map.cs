using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{    
    class Map<TKey, TValue> : IEnumerable<Item<TKey, TValue>>
    {
        private List<Item<TKey, TValue>> items = new();
        public int Count { get { return items.Count; } }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if(items.Any(a => a.Key.Equals(key)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {key}.");
            }

            items.Add(new Item<TKey, TValue>() { Key = key, Value = value });
        }

        public void Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            var item = items.SingleOrDefault(a => a.Key.Equals(key));
            if (item != null) items.Remove(item);
        }

        public void Update(TKey key, TValue newValue)
        {
            if (key == null) throw new ArgumentNullException();
            if (newValue == null) throw new ArgumentNullException();

            var item = items.SingleOrDefault(a => a.Key.Equals(key));

            if (item == null) throw new ArgumentException($"Словарь не содержит значение с ключом {key}.");

            item.Value = newValue;
        }

        public TValue Get(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            var item = items.SingleOrDefault(a => a.Key.Equals(key));

            if (item == null) throw new ArgumentException($"Словарь не содержит значение с ключом {key}.");

            return item.Value;
        }

        public IEnumerator<Item<TKey, TValue>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}

