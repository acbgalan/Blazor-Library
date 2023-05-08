using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace Library.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public BookService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
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

        public async Task<Book> GetBookById(int id)
        {
            HttpResponseMessage response = await _http.GetAsync($"api/books/{id}");

            if (response.IsSuccessStatusCode)
            {
                string stringContent = await response.Content.ReadAsStringAsync();
                Book book = JsonConvert.DeserializeObject<Book>(stringContent);
                return book;
            }

            throw new Exception("Libro no encontrado");
        }

        public async Task CreateBook(Book book)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PostAsync("api/books", content);

            if (response.IsSuccessStatusCode)
            {
                string stringContent = await response.Content.ReadAsStringAsync();
                Book newBook = JsonConvert.DeserializeObject<Book>(stringContent);
            }

            _navigationManager.NavigateTo("books");

        }

        public Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(int book)
        {
            throw new NotImplementedException();
        }
    }
}
