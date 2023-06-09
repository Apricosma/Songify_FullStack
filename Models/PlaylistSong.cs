﻿namespace Songify_FullStack.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public DateTime TimeAdded { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }

        public PlaylistSong(int songId, int playlistId)
        {
            SongId = songId;
            PlaylistId = playlistId;
            TimeAdded = DateTime.Now;
        }
    }
}
