using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Songify_FullStack.Models
{
    public class ListenerList
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Listenerlist name is required")]
        [StringLength(30, ErrorMessage = "Playlist name cannot be greater than 30 characters, or less than 2", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int UserId { get; set; }

        public ICollection<PlaylistSong> ListenerListPodcasts { get; set; } = new List<PlaylistSong>();
        public User? User { get; set; }

        public ListenerList()
        {

        }

        public ListenerList(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
