namespace Library.DTO.Request
{
    public class SaveBookDtoRequest
    {
        public int? Id { get; set; } // if id is not provided create a new book, otherwise - update an existing one
        public string Title { get; set; }       
        public string Content { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }        
     
    }
}