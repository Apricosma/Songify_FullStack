using System.ComponentModel.DataAnnotations;

namespace Songify_FullStack.Models
{
    public class MediaType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Song title is required")]
        [StringLength(200, ErrorMessage = "Song name cannot be greater than 100 characters or less than 1", MinimumLength = 1)]
        public string Title { get; set; }

        public MediaType() { }

        public MediaType(string title)
        {
            Title = title;
        }
    }
}
