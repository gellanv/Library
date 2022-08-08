using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/recommended")]
    public class RecommendedController : ControllerBase
    {
        private readonly ILogger<RecommendedController> _logger;
        private readonly ApiDBContext context;
        public RecommendedController(ILogger<RecommendedController> logger, ApiDBContext _context)
        {
            _logger = logger;
            context = _context;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return context.Books;
        }
        //### 2. Get top 10 books with high rating and number of reviews greater than 10. You can filter books by specifying genre. Order by rating
        //        GET https://{{baseUrl}}/api/recommended?genre=horror

        //# Response
        //# [{
        //# 	"id": "number",
        //# 	"title": "string",
        //# 	"author": "string",
        //# 	"rating": "decimal",          	average rating
        //# 	"reviewsNumber": "decimal"    	count of reviews
        //# }]
    }
}
