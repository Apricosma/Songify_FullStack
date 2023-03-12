namespace Songify_FullStack.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

        public User(string userName)
        {
            UserName = userName;
        }
    }
}
