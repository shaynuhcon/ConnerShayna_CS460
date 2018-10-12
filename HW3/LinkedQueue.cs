using System;

namespace HW3
{
    /// <summary>
    /// Singly linked FIFO queue
    /// </summary>
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> _front;
        private Node<T> _rear;

        public LinkedQueue()
        {
            _front = null;
            _rear = null;
        }

        public T Push(T element)
        {
            if (element == null) throw new NullReferenceException();

            if (IsEmpty())
            {
                Node<T> temp = new Node<T>(element, null);
                _rear = temp;
                _front = temp;
            }
            else
            {
                Node<T> temp = new Node<T>(element, null);
                _rear.Next = temp;
                _rear = temp;
            }

            return element;
        }

        public T Pop()
        {
            T temp;

            if (IsEmpty()) throw new QueueUnderflowException("The queue was empty when pop was invoked.");

            if(_front == _rear)
            {
                temp = _front.Data;
                _front = null;
                _rear = null;
            }  
            else
            {
                temp = _front.Data;
                _front = _front.Next;
            }

            return temp;
        }

        public bool IsEmpty()
        {
            return _front == null && _rear == null;
        }
    }
}
