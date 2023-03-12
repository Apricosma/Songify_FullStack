using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Songify_FullStack.Models;

namespace Songify_FullStack.Data
{
    public class SongifyContext : DbContext
    {
        public SongifyContext (DbContextOptions<SongifyContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<LibrarySong> LibrarySong { get; set; } = default!;
        public DbSet<SongContributor> SongContributor { get; set;} = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Playlist> Playlist { get; set; } = default!;
        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;
    }
}
