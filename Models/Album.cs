
using System.ComponentModel.DataAnnotations;

namespace Songify_FullStack.Models
{
    public class Album : MediaType
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Album(string title) : base(title)
        {
            Title = title;
        }
    }
}
