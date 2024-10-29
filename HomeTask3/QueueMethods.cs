using HomeTask3.Interfaces;

namespace HomeTask3
{
    public static class QueueMethods
    {
        public static IQueue<T> Tail<T>(this Queue<T> queue) where T : struct
        {
            Queue<T> newQueue = new Queue<T>();

            try
            {
                newQueue = queue.SetValue();
                newQueue.Dequeue();
                return newQueue;
            }
            catch
            {
                Console.WriteLine("The list is empty");
                newQueue.Enqueue(default(T));
                return newQueue;
            }
        }
    }
}
