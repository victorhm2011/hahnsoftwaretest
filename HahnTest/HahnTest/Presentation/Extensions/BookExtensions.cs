using HahnTest.Domain.Entities;
using HahnTest.Presentation.DTOs;

namespace HahnTest.Presentation.Extensions
{
    public static class BookExtensions
    {
        public static List<BookDto> ToDto(this List<Book> books)
        {
            return books.Select(x => x.ToDto()).ToList();
        }

        public static BookDto ToDto(this Book book)
        {
            return new BookDto(book);
        }
    }
}
