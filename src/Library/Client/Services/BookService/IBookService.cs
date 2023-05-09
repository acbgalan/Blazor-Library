namespace Library.Client.Services.BookService
{
    public interface IBookService
    {
        List<Book> Books { get; set; }

        Task GetBooks();
        Task<Book> GetBookById(int id);
        Task CreateBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
