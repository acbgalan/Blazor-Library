namespace Library.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; }

        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
