namespace Songify_FullStack.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        public User User { get; set; }
    }
}
