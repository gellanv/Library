using AutoMapper;
using Library.Data;
using Library.Data.Models;
using Library.DTO.Request;
using Library.DTO.Response;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService
    {
        private readonly ApiDBContext context;
        private readonly IConfiguration config;
        readonly IMapper mapper;
        public BookService(IMapper _mapper, ApiDBContext _context, IConfiguration _config)
        {
            this.mapper = _mapper;
            this.context = _context;
            this.config = _config;
        }

        public async Task<List<GetAllBooksDtoResponse>> GetAllBooks(string order)
        {
            var result = order == "title" ?
                await context.Books.Include(b => b.Ratings).Include(b => b.Reviews).OrderBy(x => x.Title).ToListAsync() :
                await context.Books.Include(b => b.Ratings).Include(b => b.Reviews).OrderBy(x => x.Author).ToListAsync();

            List<GetAllBooksDtoResponse> getAllBooksDtoResponse = new List<GetAllBooksDtoResponse>();
            result.ForEach((book) =>
            {
                GetAllBooksDtoResponse tempBook = mapper.Map<GetAllBooksDtoResponse>(book);
                tempBook.ReviewNumber = book.Reviews.Count();
                tempBook.Rating = book.Ratings.Select(x => x.Score).Average();

                getAllBooksDtoResponse.Add(tempBook);
            });

            return getAllBooksDtoResponse;
        }

        public async Task<GetBookByIdDtoResponse> GetBookById(int id)
        {
            var result = await context.Books.Where(b => b.Id == id).Include(b => b.Reviews).Include(b => b.Ratings).FirstOrDefaultAsync();

            GetBookByIdDtoResponse book = mapper.Map<GetBookByIdDtoResponse>(result);
            book.Rating = result.Ratings.Select(x => x.Score).Average();

            if (result.Reviews.Count > 0)
            {
                book.reviewDtos = new List<GetBookByIdDtoResponse.ReviewDto>();
                result.Reviews.ToList().ForEach((rev) =>
                {
                    GetBookByIdDtoResponse.ReviewDto reviewDto = mapper.Map<GetBookByIdDtoResponse.ReviewDto>(rev);
                    book.reviewDtos.Add(reviewDto);
                });
            }

            return book;
        }

        public async Task DellBookById(int id, string secret)
        {
            var SecretKey = config.GetSection("Key:KeyForDell").Value;
            if (secret.Trim() != SecretKey)
                throw new Exception();
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            context.Books.Remove(book);
            var result = await context.SaveChangesAsync();
        }

        public async Task<int> AddBook(SaveBookDtoRequest saveBookDtoRequest, IFormFile image)
        {
            string base64Image = ConverImage(image);
            Book book = mapper.Map<Book>(saveBookDtoRequest);
            book.Cover = base64Image;
            context.Books.Add(book);
            await context.SaveChangesAsync();

            return book.Id;
        }
        public async Task<int> UpdateBook(SaveBookDtoRequest saveBookDtoRequest, IFormFile image)
        {
            string base64Image = ConverImage(image);

            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == saveBookDtoRequest.Id);
            mapper.Map(saveBookDtoRequest, book);
            book.Cover = base64Image;
            await context.SaveChangesAsync();
            return book.Id;
        }

        public string ConverImage(IFormFile photo)
        {
            //byte[] image = null;
            //using (var binaryReader = new BinaryReader(photo.OpenReadStream()))
            //{
            //    image = binaryReader.ReadBytes((int)photo.Length);
            //}
            string base64Image = ""; /*= Convert.ToBase64String(image)*/


            if (photo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    //var fileBytes = ms.ToArray();
                    base64Image = Convert.ToBase64String(ms.ToArray());
                }
            }
            return base64Image;
        }
    }
}
