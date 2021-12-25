using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class Queue<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public T First { get { return IsEmpty ? throw new InvalidOperationException("Очередь пустая") : head.Data; } }
        public T Last { get { return IsEmpty ? throw new InvalidOperationException("Очередь пустая") : tail.Data; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);

            if (IsEmpty)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;

            count++;
        }

        public T Dequeu()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пустая");
            }

            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

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
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
