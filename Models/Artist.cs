using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Artist name is required")]
        [StringLength(50, ErrorMessage = "Artist name cannot be more than 50 characters or less than 1", MinimumLength = 1)]
        public string Name { get; set; }

        public ICollection<Contributor> Contributors { get; set; }

        [NotMapped]
        public List<Album> Albums { get; set; }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
