using System.ComponentModel.DataAnnotations;

namespace Songify_FullStack.Models
{
    public class MediaItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Song title is required")]
        [StringLength(200, ErrorMessage = "Song name cannot be greater than 100 characters or less than 1", MinimumLength = 1)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Song duration is required")]
        [Range(1, 3600, ErrorMessage = "Song length cannot be more than an hour, or less than 1 second")]
        public int DurationSeconds { get; set; }

        public ICollection<Contributor> Contributors { get; set; }

        public MediaItem() { }

        public MediaItem(string title, int durationSeconds)
        {
            Title = title;
            DurationSeconds = durationSeconds;
        }
    }
}
