using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{    
    class Set<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();
        public int Count { get { return items.Count; } }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            else if(!items.Contains(item))
            {
                items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            else if (!items.Contains(item))
            {
                throw new KeyNotFoundException();
            }
            items.Remove(item);
        }

        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException();
            }
            if (set2 == null)
            {
                throw new ArgumentNullException();
            }

            var resultSet = new Set<T>();

            foreach (var item in set1)
            {
                resultSet.Add(item);
            }
            foreach (var item in set2)
            {
                resultSet.Add(item);
            }

            return resultSet;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException();
            }
            if (set2 == null)
            {
                throw new ArgumentNullException();
            }

            var resultSet = new Set<T>();

            foreach (var item in set1)
            {
                if (set2.items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            return resultSet;
        }

        public static Set<T> Diference(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException();
            }
            if (set2 == null)
            {
                throw new ArgumentNullException();
            }

            var resultSet = new Set<T>();

            foreach (var item in set1)
            {
                if (!set2.items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }
            foreach (var item in set2)
            {
                if (!set1.items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            return resultSet;
        }

        public static bool Subset(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException();
            }
            if (set2 == null)
            {
                throw new ArgumentNullException();
            }

            return set1.All(a => set2.Contains(a));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
