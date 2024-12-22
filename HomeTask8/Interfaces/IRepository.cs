namespace HomeTask8.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Save(T catalog);
        T Load();
    }
}
