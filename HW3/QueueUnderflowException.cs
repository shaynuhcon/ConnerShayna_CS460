using System;

namespace HW3
{
    public class QueueUnderflowException : Exception
    {
        public QueueUnderflowException() : base() {}

        public QueueUnderflowException(string message) : base(message: message){}
    }
}
