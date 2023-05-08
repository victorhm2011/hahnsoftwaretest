using HahnTest.Domain.Entities;
using HahnTest.Domain.Repositories;

namespace HahnTest.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Book book)
        {
            await _repository.AddAsync(book);
        }

        public async Task UpdateAsync(Book book)
        {
            await _repository.UpdateAsync(book);
        }

        public async Task DeleteAsync(Book book)
        {
            await _repository.DeleteAsync(book);
        }
    }
}
