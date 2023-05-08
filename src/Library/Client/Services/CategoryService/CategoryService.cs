using Newtonsoft.Json;

namespace Library.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            HttpResponseMessage response = await _http.GetAsync("api/categories");

            if (response.IsSuccessStatusCode)
            {
                string stringContent = await response.Content.ReadAsStringAsync();
                Categories = JsonConvert.DeserializeObject<List<Category>>(stringContent);
            }
        }
    }
}
