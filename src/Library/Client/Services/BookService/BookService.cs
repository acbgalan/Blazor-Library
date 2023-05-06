
using Newtonsoft.Json;

namespace Library.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public List<Book> Books { get; set; } = new List<Book>();

        public async Task GetBooks()
        {
            HttpResponseMessage response = await _http.GetAsync("api/books");

            if (response.IsSuccessStatusCode)
            {
                string stringContent = await response.Content.ReadAsStringAsync();
                Books = JsonConvert.DeserializeObject<List<Book>>(stringContent);
            }
        }


    }
}
