using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class Deque<T> : IEnumerable<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public T First { get { return IsEmpty ? throw new InvalidOperationException("Дек пуст") : head.Data; } }
        public T Last { get { return IsEmpty ? throw new InvalidOperationException("Дек пуст") : tail.Data; } }

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (IsEmpty)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;

            count++;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if(IsEmpty)
            {
                tail = node;
            }
            else
            {
                head.Previous = node;
                node.Next = head;
            }
            head = node;

            count++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуст");
            }

            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            count--;
            return output;
        }

        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуст");
            }

            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            count--;
            return output;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
