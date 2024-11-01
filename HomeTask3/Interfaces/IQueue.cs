namespace HomeTask3.Interfaces
{
    public interface IQueue<T> where T : struct
    {
        public void Enqueue(T element);
        public T Dequeue();
        public bool IsEmpty();
    }
}
