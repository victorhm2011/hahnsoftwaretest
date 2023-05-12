using HahnTest.Domain.Entities;
using HahnTest.Domain.Repositories;
using HahnTest.Domain.Services;
using HahnTest.Presentation.DTOs;
using AutoMapper;

namespace HahnTest.Application.Services
{
    public class BookService
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

        public async Task<BookDto> GetByIdAsync(string id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var createdBook = _bookRepository.CreateAsync(book);
            return _mapper.Map<BookDto>(createdBook);
        }

        public async Task<BookDto> UpdateAsync(string id, BookDto bookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return null;
            }
            var book = _mapper.Map<Book>(bookDto);
            var updatedBook = await _bookRepository.UpdateAsync(book);
            return _mapper.Map<BookDto>(updatedBook);
        }
        public async Task DeleteAsync(string id)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook != null)
            {
                await _bookRepository.DeleteAsync(existingBook);
            }
        }
    }
}
