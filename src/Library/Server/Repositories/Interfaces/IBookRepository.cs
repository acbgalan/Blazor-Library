namespace Library.Server.Repositories.Interfaces
{
    public interface IBookRepository : IRepositoryAsync<Book>
    {
        Task<bool> ExitsAsync(string title);
    }
}
