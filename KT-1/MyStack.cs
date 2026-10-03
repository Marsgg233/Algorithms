using System;

namespace KT_1
{
    public class MyStack<T>
    {
        private SinglyLinkedList<T> list;

        public MyStack()
        {
            list = new SinglyLinkedList<T>();
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsEmpty
        {
            get { return list.IsEmpty; }
        }

        public void Push(T value)
        {
            list.AddFirst(value);
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            return list.RemoveFirst();
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            return list.PeekFirst();
        }
    }
}
