using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Next = tail;
            }
            tail = node;

            count++;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (count == 0)
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

        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }

                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;

            while(current != null)
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
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
