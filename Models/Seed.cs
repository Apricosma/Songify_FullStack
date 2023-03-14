using Microsoft.EntityFrameworkCore;
using Songify_FullStack.Data;

namespace Songify_FullStack.Models
{
    public class Seed
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new SongifyContext(serviceProvider.GetRequiredService<DbContextOptions<SongifyContext>>());

            // delete and re-seed
            // !!!!!!!!!!!!! REMOVE WHEN FINISHED !!!!!!!!!!!!!!!!!
            //context.Database.EnsureDeleted();
            //context.Database.Migrate();

            User UserOne = new User("Apricosma");
            if (!context.User.Any())
            {
                context.User.Add(UserOne);
            }
            await context.SaveChangesAsync();

            Playlist playlistOne = new Playlist("Favorite Songs", 1);
            if (!context.Playlist.Any())
            {
                context.Playlist.Add(playlistOne);
            }
            await context.SaveChangesAsync();

            Artist[] allArtists = new Artist[]
            {
                new Artist("Camellia"),
                new Artist("hanahata"),
                new Artist("Figgie"),
            };

            if (!context.Artist.Any())
            {
                foreach (Artist artist in allArtists)
                {
                    context.Add(artist);
                }
            }
            await context.SaveChangesAsync();

            Album[] allAlbums = new Album[]
            {
                new Album("crystallized"),
                new Album("2003 Toyota Corolla"),
                new Album("Figgie"),
            };
            
            if (!context.Album.Any())
            {
                foreach(Album album in allAlbums)
                {
                    context.Add(album);
                }
            }
            await context.SaveChangesAsync();

            Song[] AllSongs = new Song[]
            {
                // crystallized
                new Song("Rain of Amethyst", 441, 1),
                new Song("Artificial Snow", 266, 1),
                new Song("amorphous", 406, 1),
                new Song("First Town Of This Journey", 60 * 6 + 46, 1),
                new Song("yesterday", 60 * 5 + 4, 1),
                new Song("Light it up", 60 * 6 + 14, 1),
                new Song("NUCLEAR-STAR", 60 * 4 + 54, 1),
                new Song("crystallized", 60 * 4 + 37, 1),
                new Song("liquated", 60 * 5 + 6, 1),

                // 2003 toyota corolla
                // This is a real album I promise, Zach
                new Song("2003 Toyota Corolla", 7 * 60 + 6, 2),
                new Song("2004 Toyota Corolla", 5 * 60 + 24, 2),
                new Song("2005 Toyota Corolla", 1 * 60 + 32, 2),
                new Song("2006 Toyota Corolla", 25 * 60 + 7, 2),
                new Song("2007 Toyota Corolla", 12 * 60 + 41, 2),
                new Song("2008 Toyota Corolla", 7 * 60 + 45, 2),
                new Song("2009 Toyota Corolla", 14 * 60 + 8, 2),
                new Song("2010 Toyota Corolla", 3 * 60 + 16, 2),

                // Figgie
                new Song("Timelapse", 4*60+27, 3),
                new Song("Haze", 2*60+14, 3),
                new Song("caffeine", 2*60+14, 3),
                new Song("alive", 2*60+20, 3),

            };

            if (!context.Song.Any())
            {
                foreach (Song song in AllSongs)
                {
                    context.Add(song);
                }
            }
            await context.SaveChangesAsync();

            SongContributor[] AllSongContibutors = new SongContributor[]
            {
                //camellia
                new SongContributor(1, 1),
                new SongContributor(1, 2),
                new SongContributor(1, 3),
                new SongContributor(1, 4),
                new SongContributor(1, 5),
                new SongContributor(1, 6),
                new SongContributor(1, 7),
                new SongContributor(1, 8),
                new SongContributor(1, 9),
                //hanahata
                new SongContributor(2, 10),
                new SongContributor(2, 11),
                new SongContributor(2, 12),
                new SongContributor(2, 13),
                new SongContributor(2, 14),
                new SongContributor(2, 15),
                new SongContributor(2, 16),
                new SongContributor(2, 17),
                //figgie
                new SongContributor(3, 18),
                new SongContributor(3, 19),
                new SongContributor(3, 20),
                new SongContributor(3, 21),
            };

            
            if (!context.SongContributor.Any())
            {
                foreach (SongContributor songContributor in AllSongContibutors)
                {
                    context.Add(songContributor);
                }

            }
            await context.SaveChangesAsync();

            PlaylistSong playlistSongOne = new PlaylistSong(1, 1);
            if (!context.PlaylistSong.Any())
            {
                context.PlaylistSong.Add(playlistSongOne);
            }
            await context.SaveChangesAsync();

            LibrarySong librarysongOne = new LibrarySong(1, 1);
            if (!context.LibrarySong.Any())
            {
                context.LibrarySong.Add(librarysongOne);
            }
            await context.SaveChangesAsync();

        }
    }
}
