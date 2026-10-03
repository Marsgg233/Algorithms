using System;
using System.Collections;
using System.Collections.Generic;

namespace KT_1
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return head == null; }
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
            if (tail == null)
            {
                tail = head;
            }
            count++;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                if (tail != null)
                {
                    tail.Next = newNode;
                }
                tail = newNode;
            }
            count++;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            T value = head.Value;
            head = head.Next;
            count--;

            if (head == null)
            {
                tail = null;
            }

            return value;
        }

        public T PeekFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }
            return head.Value;
        }

        public bool Contains(T value)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
