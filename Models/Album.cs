
using System.ComponentModel.DataAnnotations;

namespace Songify_FullStack.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Song name cannot be more than 100 characters, or less than 2", MinimumLength = 2)]
        public string Title { get; set; }

        public ICollection<Song> Songs { get; set; }

        public Album(string title) 
        {
            Title = title;
        }
    }
}
