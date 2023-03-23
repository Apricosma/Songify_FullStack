using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Songify_FullStack.Models;

namespace Songify_FullStack.Data
{
    public class SongifyContext : DbContext
    {
        public SongifyContext(DbContextOptions<SongifyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<ListenerList>()
                .HasOne(ll => ll.User)
                .WithMany(u => u.ListenerLists)
                .HasForeignKey(ll => ll.UserId);

            modelBuilder.Entity<MediaType>()
                .HasDiscriminator<string>("MediaType")
                .HasValue<Album>("Album")
                .HasValue<Podcast>("Podcast");

            modelBuilder.Entity<MediaItem>()
                .HasDiscriminator<string>("MediaItemType")
                .HasValue<Song>("Song")
                .HasValue<Episode>("Episode");

            modelBuilder.Entity<Contributor>()
                .HasOne(sc => sc.Artist)
                .WithMany(a => a.Contributors)
                .HasForeignKey(sc => sc.ArtistId);

            modelBuilder.Entity<Contributor>()
                .HasOne(sc => sc.Podcast)
                .WithMany(p => p.Contributions)
                .HasForeignKey(sc => sc.PodcastId);

            modelBuilder.Entity<Contributor>()
                .HasOne(sc => sc.Song)
                .WithMany(s => s.Contributors)
                .HasForeignKey(sc => sc.SongId);
        }


        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<LibrarySong> LibrarySong { get; set; } = default!;
        public DbSet<Contributor> Contributor { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Playlist> Playlist { get; set; } = default!;
        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;
        public DbSet<MediaType> mediaTypes { get; set; } = default!;
        public DbSet<MediaItem> mediaItems { get; set; } = default!;
        public DbSet<Podcast> Podcast { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<ListenerList> ListenerList { get; set; } = default!;
        public DbSet<ListenerListPodcasts> ListenerListPodcasts { get; set; } = default!;
    }
}
