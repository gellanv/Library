using Library.DTO.Request;
using Library.DTO.Response;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookService bookService;
        private readonly ReviewService reviewService;
        private readonly RatingService ratingService;
        public BooksController(BookService _bookService, ReviewService _reviewService, RatingService _ratingService)
        {
            bookService = _bookService;
            reviewService = _reviewService;
            ratingService = _ratingService;
        }

        //https://{{baseUrl}}/api/books?order=author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllBooksDtoResponse>>> GetAllBooks(string? order)
        {
            IEnumerable<GetAllBooksDtoResponse> getAllBooksDtoResponse = await bookService.GetAllBooks(order);

            if (getAllBooksDtoResponse == null)
                return new NoContentResult();
            else return Ok(getAllBooksDtoResponse);
        }

        //https://{{baseUrl}}/api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookByIdDtoResponse>> GetBookById(int id)
        {
            GetBookByIdDtoResponse getBookByIdDtoResponse = await bookService.GetBookById(id);

            return Ok(getBookByIdDtoResponse);
        }

        //DELETE https://{{baseUrl}}/api/books/{id}?secret=qwerty
        [HttpDelete("{id}")]
        public async Task<IActionResult> DellBookById(int id, [FromForm] string secret)
        {
            await bookService.DellBookById(id, secret);

            return Ok();
        }

        //POST https://{{baseUrl}}/api/books/save
        [HttpPost]
        public async Task<ActionResult<int>> SaveBook([FromForm] SaveBookDtoRequest saveBookDtoRequest, IFormFile image)
        {
            var result = saveBookDtoRequest.Id == null ? await bookService.AddBook(saveBookDtoRequest, image)
                : await bookService.UpdateBook(saveBookDtoRequest, image);

            return Created("api/books/save", new { Id = result });
        }

        //    PUT https://{{baseUrl}}/api/books/{id}/review
        [HttpPut("{id}/review")]
        public async Task<ActionResult<int>> SaveReview(int id, SaveReviewDtoRequest saveReviewDtoRequest)
        {
            var result = await reviewService.SaveReview(id, saveReviewDtoRequest);

            return Created($"api/books/{id}/review", new { Id = result });
        }


        //PUT https://{{baseUrl}}/api/books/{id}/rate
        [HttpPut("{id}/rate")]
        public async Task<IActionResult> AddRate(int id, int score)
        {
            await ratingService.AddRaiting(id, score);

            return Ok();
        }
    }
}
