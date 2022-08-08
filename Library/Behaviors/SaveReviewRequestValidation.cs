using FluentValidation;
using Library.DTO.Request;

namespace Library.Behaviors
{
    public class SaveReviewRequestValidation: AbstractValidator<SaveReviewDtoRequest>
    {
        public SaveReviewRequestValidation()
        {
            RuleFor(review => review.Message).NotEmpty().Length(5, 100);
            RuleFor(review => review.Reviewer).NotEmpty().Length(5, 25);
        }
    }
}
