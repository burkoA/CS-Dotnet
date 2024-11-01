using HomeTask3.Interfaces;

namespace HomeTask3
{
    public static class QueueMethods
    {
        public static IQueue<T> Tail<T>(this Queue<T> queue) where T : struct
        {
            Queue<T> newQueue = new Queue<T>();
            Queue<T> oldQueue = new Queue<T>();

            if (queue.IsEmpty())
            {
                newQueue.Enqueue(default);
                return newQueue;
            }

            T value = queue.Dequeue();

            oldQueue.Enqueue(value);

            while (!queue.IsEmpty())
            {
                value = queue.Dequeue();
                oldQueue.Enqueue(value);
                newQueue.Enqueue(value);
            }

            while (!oldQueue.IsEmpty())
            {
                value = oldQueue.Dequeue();
                queue.Enqueue(value);
            }

            return newQueue;
        }
    }
}
