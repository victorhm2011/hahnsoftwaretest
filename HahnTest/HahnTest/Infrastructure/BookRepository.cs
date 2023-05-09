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

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Book>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _dbContext.Set<Book>().AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book existingBook, Book updatedBook)
        {
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.PublishDate = updatedBook.PublishDate;
            existingBook.Price = updatedBook.Price;
            await _dbContext.SaveChangesAsync();
            return existingBook;
        }

        public async Task DeleteAsync(Book book)
        {
            _dbContext.Set<Book>().Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        Task<List<Book>> IBookRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Book> IBookRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IBookRepository.AddAsync(Book book)
        {
            throw new NotImplementedException();
        }

        Task IBookRepository.UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
