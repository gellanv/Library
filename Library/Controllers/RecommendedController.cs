using Library.Data;
using Library.DTO.Response;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/recommended")]
    public class RecommendedController : ControllerBase
    {
        private readonly ApiDBContext context;
        private readonly BookService bookService;
        public RecommendedController(ApiDBContext _context, BookService _bookService)
        {
            context = _context;
            bookService = _bookService;
        }

        //GET https://{{baseUrl}}/api/recommended?genre=horror
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllBooksDtoResponse>>> GetRecommendBooks(string? genre)
        {
            IEnumerable<GetAllBooksDtoResponse> getAllBooksDtoResponse = await bookService.GetRecommendBooks(genre);

            if (getAllBooksDtoResponse == null)
                return new NoContentResult();
            else return Ok(getAllBooksDtoResponse);
        }
    }
}