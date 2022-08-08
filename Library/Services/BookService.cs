using AutoMapper;
using FluentValidation.Results;
using Library.Behaviors;
using Library.Data;
using Library.Data.Models;
using Library.DTO.Request;
using Library.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Services
{
    public class BookService
    {
        private readonly ApiDBContext context;
        private readonly IConfiguration config;
        readonly IMapper mapper;
        private readonly SaveBookRequestValidation saveBookRequestValidation;
        private readonly VariableValidation variableValidation;
        public BookService(IMapper _mapper, ApiDBContext _context, IConfiguration _config, SaveBookRequestValidation _saveBookValidation, VariableValidation _variableValidation)
        {
            this.mapper = _mapper;
            this.context = _context;
            this.config = _config;
            this.saveBookRequestValidation = _saveBookValidation;
            this.variableValidation = _variableValidation;
        }

        public async Task<List<GetAllBooksDtoResponse>> GetAllBooks(string? order)
        {
            List<Book> result = null;

            if (order == null || order == "Title")
                result = await context.Books.Include(b => b.Ratings).Include(b => b.Reviews).OrderBy(x => x.Title).ToListAsync();
            else
                result = await context.Books.Include(b => b.Ratings).Include(b => b.Reviews).OrderBy(x => x.Author).ToListAsync();

            if (result.Count != 0)
            {
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
            else return null;
        }

        public async Task<List<GetAllBooksDtoResponse>> GetRecommendBooks(string? genre)
        {
            var allBook = genre != null ?
                         await context.Books.Include(b => b.Ratings).Include(b => b.Reviews).Where(x => x.Genre == genre).ToListAsync() :
                         await context.Books.Include(b => b.Ratings).Include(b => b.Reviews).ToListAsync();

            if (allBook.Count != 0)
            {
                List<GetAllBooksDtoResponse> getAllBooksDtoResponse = new List<GetAllBooksDtoResponse>();
                allBook.ForEach((book) =>
                {
                    GetAllBooksDtoResponse tempBook = mapper.Map<GetAllBooksDtoResponse>(book);
                    tempBook.ReviewNumber = book.Reviews.Count();
                    tempBook.Rating = book.Ratings.Select(x => x.Score).Average();

                    getAllBooksDtoResponse.Add(tempBook);
                });

                var res = getAllBooksDtoResponse.Where(x => x.ReviewNumber > 10).OrderByDescending(x => x.Rating).Take(10).ToList();

                return res;
            }
            else return null;
        }

        public async Task<GetBookByIdDtoResponse> GetBookById(int id)
        {
            variableValidation.CheckId(id, $"BookId ");

            var result = await context.Books.Where(b => b.Id == id).Include(b => b.Reviews).Include(b => b.Ratings).FirstOrDefaultAsync();
            variableValidation.CheckObjectForNull(result, $"book with id - {id}");

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
            variableValidation.CheckId(id, $"BookId ");

            var SecretKey = config.GetSection("Key:KeyForDell").Value;
            if (secret.Trim() != SecretKey)
                throw new Exception("SecretKey was wrong");

            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            variableValidation.CheckObjectForNull(book, $"book with id - {id}");

            context.Books.Remove(book);
            var result = await context.SaveChangesAsync();
        }

        public async Task<int> AddBook(SaveBookDtoRequest saveBookDtoRequest, IFormFile image)
        {
            ValidationResult results = await saveBookRequestValidation.ValidateAsync(saveBookDtoRequest);
            if (!results.IsValid)
            {
                throw new Exception(results.ToString("~"));
            }

            string base64Image = ConverImage(image);

            Book book = mapper.Map<Book>(saveBookDtoRequest);
            book.Cover = base64Image;
            context.Books.Add(book);
            await context.SaveChangesAsync();

            return book.Id;
        }
        public async Task<int> UpdateBook(SaveBookDtoRequest saveBookDtoRequest, IFormFile image)
        {
            ValidationResult results = await saveBookRequestValidation.ValidateAsync(saveBookDtoRequest);
            if (!results.IsValid)
            {
                throw new Exception(results.ToString("~"));
            }

            string base64Image = ConverImage(image);

            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == saveBookDtoRequest.Id);
            variableValidation.CheckObjectForNull(book, $"book with id - {saveBookDtoRequest.Id}");

            mapper.Map(saveBookDtoRequest, book);
            book.Cover = base64Image;
            await context.SaveChangesAsync();
            return book.Id;
        }

        public string ConverImage(IFormFile photo)
        {
            string base64Image = "";

            if (photo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    base64Image = Convert.ToBase64String(ms.ToArray());
                }
            }
            return base64Image;
        }
    }
}
