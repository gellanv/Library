using AutoMapper;
using Library.Data.Models;
using Library.DTO.Request;
using Library.DTO.Response;

namespace Library.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetAllBooksDtoResponse>().ReverseMap();
            CreateMap<Book, GetBookByIdDtoResponse>().ReverseMap();
            CreateMap<Review, GetBookByIdDtoResponse.ReviewDto>().ReverseMap();
            CreateMap<Book, SaveBookDtoRequest>().ReverseMap();
            CreateMap<Review, SaveReviewDtoRequest>().ReverseMap();
        }
    }
}