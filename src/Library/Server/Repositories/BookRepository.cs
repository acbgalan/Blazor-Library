using Library.Server.Data;
using Library.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Web;

namespace Library.Server.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.Include(x => x.Category).ToListAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _context.Books.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Book entity)
        {
            await Task.Run(() =>
            {
                _context.Books.Update(entity);
            });

        }

        public async Task DeleteAsync(int id)
        {
            Book book = await this.GetAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public async Task DeleteAsync(Book entity)
        {
            await Task.Run(() =>
            {
                _context.Books.Remove(entity);
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await _context.Books.AnyAsync(x => x.Id == id);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
