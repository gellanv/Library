using Library.Behaviors;
using Library.Data;
using Library.Data.Models;

namespace Library.Services
{
    public class RatingService
    {
        private readonly ApiDBContext context;
        private readonly VariableValidation variableValidation;
        public RatingService(ApiDBContext _context, VariableValidation _variableValidation)
        {
            this.context = _context;
            this.variableValidation = _variableValidation;
        }

        public async Task AddRaiting(int idBook, int score)
        {
            variableValidation.CheckId(idBook, $"BookId ");
            variableValidation.CheckScore(score);

            Rating raiting = new Rating() { BookId = idBook, Score = score };
            context.Ratings.Add(raiting);
            await context.SaveChangesAsync();
        }
    }
}
