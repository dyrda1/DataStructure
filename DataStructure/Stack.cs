using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> head;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;

            count++;
        }

        public T Pop(T data)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст");
            }

            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public T Peek(T data)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст");
            }

            return head.Data;
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
