using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SongContributor> SongContributors { get; set; }

        [NotMapped]
        public List<Album> Albums { get; set; }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
