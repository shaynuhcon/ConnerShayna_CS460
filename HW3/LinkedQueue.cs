using System;

namespace HW3
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        public T Push(T element)
        {
            if (element == null) throw new NullReferenceException();

            if (IsEmpty())
            {
                Node<T> temp = new Node<T>(element, null);
                rear = front = temp;
            }
            else
            {
                Node<T> temp = new Node<T>(element, null);
                rear.Next = temp;
                rear = temp;
            }

            return element;
        }

        public T Pop()
        {
            T temp;

            if (IsEmpty())
            {
                temp = front.Data;
                front = null;
                rear = null;
            }
            else
            {
                temp = front.Data;
                front = front.Next;
            }

            return temp;
        }

        public bool IsEmpty()
        {
            return front == null && rear == null;
        }
    }
}
