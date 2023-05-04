using Library.Server.Data;
using Library.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category entity)
        {
            await Task.Run(() =>
            {
                _context.Categories.Update(entity);
            });
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await this.GetAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public async Task DeleteAsync(Category entity)
        {
            await Task.Run(() =>
            {
                _context.Categories.Remove(entity);
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await _context.Categories.AnyAsync(x => x.Id == id);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
