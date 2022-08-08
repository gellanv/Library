﻿namespace Library.DTO.Response
{
    public class GetAllBooksDtoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Rating { get; set; }//	average rating
        public decimal ReviewNumber { get; set; }//count of reviews
    }
}