namespace Songify_FullStack.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SongContributor> SongContributors { get; set; }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
