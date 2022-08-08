namespace Library.DTO.Response
{
    public class GetBookByIdDtoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public decimal Rating { get; set; }//	average rating
        public List<ReviewDto> reviewDtos { get; set; }//count of reviews
        public class ReviewDto
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public string Reviewer { get; set; }
        }
    }
}