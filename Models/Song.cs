namespace Songify_FullStack.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        public virtual ICollection<SongContributor> SongContributors { get; set; }

        public Song(string title, int durationSeconds, int albumId)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
        }
    }
}
