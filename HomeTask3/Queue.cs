using HomeTask3.Interfaces;

namespace HomeTask3
{
    public class Queue<T> : IQueue<T> where T : struct
    {
        private LinkedList<T> _queue;

        public Queue()
        {
            _queue = new LinkedList<T>();
        }

        public void Enqueue(T element)
        {
            _queue.AddLast(element);
        }

        public void Dequeue()
        {
            try
            {
                _queue.RemoveFirst();
            } 
            catch
            {
                throw new Exception("List is empty");
            }
        }

        public bool IsEmpty()
        {
            if(_queue == null || _queue.Count == 0)
            {
                return true;
            }

            return false;
        }

        public Queue<T> SetValue()
        {
            Queue<T> setValue = new Queue<T>();

            foreach(T value in this._queue)
            {
                setValue.Enqueue(value);
            }

            return setValue;
        }
    }
}
