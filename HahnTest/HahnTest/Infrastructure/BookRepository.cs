using HahnTest.Domain.Entities;
using HahnTest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HahnTest.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly DbContext _dbContext;

        public BookRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Set<Book>().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            return await _dbContext.Set<Book>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _dbContext.Set<Book>().AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book updatedBook)
        {
           var book = await this.GetByIdAsync(updatedBook.Id);
           book = updatedBook;
           await _dbContext.SaveChangesAsync();
           return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _dbContext.Set<Book>().Remove(book);
            await _dbContext.SaveChangesAsync();
        }

    }
}
