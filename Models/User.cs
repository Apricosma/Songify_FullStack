using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Songify_FullStack.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

        public User(string userName)
        {
            UserName = userName;
        }
    }
}
