namespace Songify_FullStack.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Song> Songs { get; set; }

        public Album(string title) 
        {
            Title = title;
        }
    }
}
