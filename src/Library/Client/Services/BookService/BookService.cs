using Library.Client.Pages;

namespace Library.Client.Services.BookService
{
    public class BookService : IBookService
    {
        public List<Book> Books { get; set; }

        public Task GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
