using HahnTest.Domain.Entities;
using HahnTest.Domain.Repositories;
using HahnTest.Domain.Services;
using HahnTest.Presentation.DTOs;
using AutoMapper;

namespace HahnTest.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var createdBook = _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(createdBook);
        }

        public async Task<BookDto> UpdateAsync(int id, BookDto bookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return null;
            }
            var book = _mapper.Map<Book>(bookDto);
            var updatedBook = await _bookRepository.UpdateAsync(existingBook, book);
            return _mapper.Map<BookDto>(updatedBook);
        }
        public async Task DeleteAsync(Guid id)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook != null)
            {
                await _bookRepository.DeleteAsync(existingBook);
            }
        }

        Task<List<Book>> IBookService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Book> IBookService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IBookService.AddAsync(Book book)
        {
            var book = _mapper.Map<Book>(bookDto);
            var createdBook = _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(createdBook);
        }

        Task IBookService.UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }

        Task IBookService.DeleteAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
