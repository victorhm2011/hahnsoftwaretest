using HahnTest.Domain.Entities;

namespace HahnTest.Domain.Repositories
{
    public interface IBookRepository
    {
        //Task<List<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(string id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book updatedBook);
        Task DeleteAsync(Book book);
    }
}
