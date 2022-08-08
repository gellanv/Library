using Library.Data;
using Library.Data.Models;

namespace Library.Services
{
    public class RatingService
    {
        private readonly ApiDBContext context;
        public RatingService(ApiDBContext _context)
        {
            this.context = _context;
        }

        public async Task AddRaiting(int idBook, int score)
        {
            Rating raiting = new Rating() { BookId = idBook, Score = score };
            context.Ratings.Add(raiting);
            await context.SaveChangesAsync();
        }
    }
}
