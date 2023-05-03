namespace Library.Server.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T Get(int id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        bool Exits(int id);
        int Save();
    }
}
