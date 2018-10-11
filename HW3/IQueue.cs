namespace HW3
{
    public interface IQueue<T>
    {
        /// <summary>
        /// Add an element to rear of queue
        /// </summary>
        /// <param name="element"></param>
        /// <returns>the element that was en-queued</returns>
        T Push(T element);

        /// <summary>
        /// Remove and return the front element
        /// </summary>
        /// <returns>the element from the front</returns>
        /// <exception cref="QueueUnderflowException">Thrown if queue is empty</exception>
        T Pop();

        /// <summary>
        /// Test if queue is empty
        /// </summary>
        /// <returns>true if queue is empty, otherwise false</returns>
        bool IsEmpty();
    }
}
