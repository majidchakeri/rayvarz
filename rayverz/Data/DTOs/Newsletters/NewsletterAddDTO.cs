using System.ComponentModel.DataAnnotations;

namespace rayverz.Data.DTOs.Newsletters
{
    public class NewsletterAddDTO
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
