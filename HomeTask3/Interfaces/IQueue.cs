namespace HomeTask3.Interfaces
{
    public interface IQueue<T> where T : struct
    {
        public void Enqueue(T element);
        public void Dequeue();
        public bool IsEmpty();
    }
}
