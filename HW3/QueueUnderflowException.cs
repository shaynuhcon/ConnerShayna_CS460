using System;

namespace HW3
{
    /// <summary>
    /// Custom unchecked exception to represent situations where an
    /// illegal operation was performed on an empty queue
    /// </summary>
    public class QueueUnderflowException : Exception
    {
        public QueueUnderflowException() : base() {}

        public QueueUnderflowException(string message) : base(message: message){}
    }
}
