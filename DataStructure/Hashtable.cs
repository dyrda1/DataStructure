using System;
using System.Collections.Generic;

namespace DataStructure
{
    class Hashtable<TKey, TValue>
    {
        private Dictionary<int, List<Item<TKey, TValue>>> items = new Dictionary<int, List<Item<TKey, TValue>>>();

        private static int GetHash(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            return key.ToString().Length;
        }

        public void Insert(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if (value == null)
            {
                throw new ArgumentNullException();
            }
                       
            var hash = GetHash(key);

            if (items.ContainsKey(hash))
            {
                foreach (var item in items[hash])
                {
                    dynamic newKey = item.Key;
                    if (newKey == key)
                    {
                        throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. Ключ должен быть уникален.");
                    }
                }
                items[hash].Add(new Item<TKey, TValue>(key, value));
            }
            else
            {
                var newList = new List<Item<TKey, TValue>>
                {
                    new Item<TKey, TValue>(key, value)
                };
                items.Add(GetHash(key), newList);
            }
        }

        public void Delete(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            var hash = GetHash(key);
            var deleteItem = new Item<TKey, TValue>();

            foreach (var item in items[hash])
            {
                dynamic newKey = item.Key;
                if (newKey == key)
                {
                    deleteItem = item;
                    break;
                }
            }

            items[hash].Remove(deleteItem);
        }

        public void Print()
        {
            foreach (var item in items[2])
            {
                Console.WriteLine(item);
            }
        }
    }
}
