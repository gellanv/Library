using AutoMapper;
using Library.Behaviors;
using Library.Data;
using Library.Data.Models;
using Library.DTO.Request;
using FluentValidation.Results;
using FluentValidation;

namespace Library.Services
{
    public class ReviewService
    {
        private readonly ApiDBContext context;
        private readonly IMapper mapper;
        private readonly SaveReviewRequestValidation saveReviewValidation;
        private readonly VariableValidation variableValidation;
        public ReviewService(IMapper _mapper, ApiDBContext _context, SaveReviewRequestValidation _validationRules, VariableValidation _variableValidation)
        {
            this.mapper = _mapper;
            this.context = _context;
            this.saveReviewValidation = _validationRules;
            this.variableValidation = _variableValidation;
        }

        public async Task<int> SaveReview(int id, SaveReviewDtoRequest saveReviewDtoRequest)
        {
            variableValidation.CheckId(id, $"BookId ");

            //saveReviewValidation.ValidateAndThrow(saveReviewDtoRequest);

            ValidationResult results = await saveReviewValidation.ValidateAsync(saveReviewDtoRequest);
            if (!results.IsValid)
                throw new ValidationException(results.ToString("~"));

            Review review = mapper.Map<Review>(saveReviewDtoRequest);
            review.BookId = id;
            context.Reviews.Add(review);
            await context.SaveChangesAsync();

            return review.Id;
        }
    }
}
