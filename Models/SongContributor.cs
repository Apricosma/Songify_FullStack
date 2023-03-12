namespace Songify_FullStack.Models
{
    public class SongContributor
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int SongId { get; set; }

        public Artist Artist { get; set; }
        public Song Song { get; set; }
    }
}
