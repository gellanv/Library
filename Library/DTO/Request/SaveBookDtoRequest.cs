using System.ComponentModel.DataAnnotations;

namespace Library.DTO.Request
{
    public class SaveBookDtoRequest
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Author { get; set; }

    }
}