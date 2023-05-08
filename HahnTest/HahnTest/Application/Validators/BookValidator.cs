using FluentValidation;
using HahnTest.Presentation.DTOs;

namespace HahnTest.Application.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.PublishDate).NotEmpty();
            RuleFor(x => x.Isbn).NotEmpty().Length(13);
        }
    }
}
