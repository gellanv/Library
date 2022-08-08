using AutoMapper;
using Library.Data;
using Library.Data.Models;
using Library.DTO.Request;

namespace Library.Services
{
    public class ReviewService
    {
        private readonly ApiDBContext context;
        readonly IMapper mapper;
        public ReviewService(IMapper _mapper, ApiDBContext _context)
        {
            this.mapper = _mapper;
            this.context = _context;
        }

        public async Task<int> SaveReview(int id, SaveReviewDtoRequest saveReviewDtoRequest)
        {
            Review review = mapper.Map<Review>(saveReviewDtoRequest);
            review.BookId = id;
            context.Reviews.Add(review);
            await context.SaveChangesAsync();

            return review.Id;
        }
    }
}
