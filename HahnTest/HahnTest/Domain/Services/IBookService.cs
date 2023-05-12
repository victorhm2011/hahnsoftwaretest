using HahnTest.Domain.Entities;

namespace HahnTest.Domain.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(string id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }
}
