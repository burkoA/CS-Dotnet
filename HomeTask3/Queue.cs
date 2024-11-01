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

        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T value = _queue.First.Value;
                _queue.RemoveFirst();
                return value;
            }
            else
            {
                throw new Exception("List is empty");
            }
        }

        public bool IsEmpty()
        {
            if (_queue.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
