namespace Songify_FullStack.Models
{
    public class ListenerListPodcasts
    {
        //public DateTime TimeAdded { get; set; }

        //public virtual Podcast Podcast { get; set; }
        //public virtual ListenerList ListenerList { get; set; }

        //public ListenerListPodcasts()
        //{

        //}

        //public ListenerListPodcasts(int listenerListId, int podcastId) : base(listenerListId, podcastId)
        //{
        //    TimeAdded = DateTime.Now;
        //}

        public int Id { get; set; }
        public int PodcastId { get; set; }
        public int ListenerListId { get; set; }
        public DateTime TimeAdded { get; set; }

        public virtual Podcast Podcast { get; set; }
        public virtual ListenerList ListenerList { get; set; }

        public ListenerListPodcasts()
        {

        }

        public ListenerListPodcasts(int podcastId, int listenerListId)
        {
            PodcastId = podcastId;
            ListenerListId = listenerListId;
            TimeAdded = DateTime.Now;
        }
    }
}
