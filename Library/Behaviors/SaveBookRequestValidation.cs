using FluentValidation;
using Library.DTO.Request;

namespace Library.Behaviors
{
    public class SaveBookRequestValidation : AbstractValidator<SaveBookDtoRequest>
    {
        public SaveBookRequestValidation()
        {
            RuleFor(book => book.Title).NotEmpty().Length(3, 20);
            RuleFor(book => book.Content).NotEmpty().Length(20, 200);
            RuleFor(book => book.Genre).NotEmpty().Length(3, 20);
            RuleFor(book => book.Author).NotEmpty().Length(3, 50);
        }
    }
}