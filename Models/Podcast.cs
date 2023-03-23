namespace Songify_FullStack.Models
{
    public class Podcast : MediaType
    {
        public virtual ICollection<Episode> Episodes { get; set;}
        public virtual ICollection<Contributor> Contributions { get; set;}
        public virtual ICollection<ListenerListPodcasts> ListenerListPodcasts { get; set;}

        public Podcast(string title) : base(title)
        {
            Title = title;
        }
    }
}
