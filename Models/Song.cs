namespace Songify_FullStack.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
    }
}
