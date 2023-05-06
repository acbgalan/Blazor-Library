
namespace Library.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public List<Book> Books { get; set; }

        public async Task GetBooks()
        {
            HttpResponseMessage response = await _http.GetAsync("api/books");
            
        }
    }
}
