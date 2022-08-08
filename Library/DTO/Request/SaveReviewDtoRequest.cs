using System.ComponentModel.DataAnnotations;

namespace Library.DTO.Request
{
    public class SaveReviewDtoRequest
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string Reviewer { get; set; }
    }
}
