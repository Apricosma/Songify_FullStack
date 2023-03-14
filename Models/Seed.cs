using Microsoft.EntityFrameworkCore;
using Songify_FullStack.Data;
using System.Drawing.Text;

namespace Songify_FullStack.Models
{
    public class Seed
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new SongifyContext(serviceProvider.GetRequiredService<DbContextOptions<SongifyContext>>());

            // delete and re-seed
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            User UserOne = new User("Apricosma");
            if (!context.User.Any())
            {
                context.User.Add(UserOne);
            }
            await context.SaveChangesAsync();

            Playlist[] allPlaylists = new Playlist[]
            {
                 new Playlist("Favorite Songs", 1),
                 new Playlist("Jams", 1),
                 new Playlist("Geoxor tracks", 1)
            };

            if (!context.Playlist.Any())
            {
                foreach (Playlist playlist in allPlaylists)
                {
                    context.Add(playlist);
                }

            }
            await context.SaveChangesAsync();

            Artist[] allArtists = new Artist[]
            {
                new Artist("Camellia"),
                new Artist("hanahata"),
                new Artist("Figgie"),
                new Artist("Geoxor"),
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
                new Album("Stardust"),
                new Album("U.U.F.O"),
            };

            if (!context.Album.Any())
            {
                foreach (Album album in allAlbums)
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

                // Stardust
                new Song("Only Now", 4-60+9, 4),
                new Song("Stardust", 4*60+21, 4),
                new Song("Take Me Home", 3*60+57, 4),
                new Song("Shaii",4*60+22 , 4),
                new Song("Euphoria", 3*60+2, 4),
                new Song("Nana", 4*60+11, 4),
                new Song("Restart", 3*60+49, 4),
                new Song("Cheese", 4*60+41, 4),
                new Song("Lollipop", 3*60+23, 4),

                // U.U.F.O.
                new Song("Mystery Circles Ultra / U.U.F.O.", 3*60+59, 5),
                new Song("(The) Red * Room", 3*60+51, 5),
                new Song("Labyrinth in Kowloon: Walled World", 4*60+14, 5),
                new Song("Electromagnetic Stealth Girl Born In Philadelphia", 4*60+55, 5),
                new Song("Zhuzhzhalka76", 4*60+34, 5),
                new Song("KillerToy", 4*60+37, 5),
                new Song("POLYBIUS GB SPEEDRUN -Glitchless 100% WR in 0:03:57-", 4*60+5, 5),
                new Song("Tentaclar Aliens' Epic Extraterretterrestrial Jungle Dance Party Inside Of A Super​-​Ultra​-​Mega​-​Gigantic U​.​F​.​O. (It Maybe U​.​U​.​F​.​O​.​) Silently Flying Over Illinois St.", 5*60+3, 5),
                new Song("FINAL BLENDERMAN APPEARED.", 4*60+39, 5),
                new Song("WYSI -When You See It-", 3*60+17, 5),
                new Song("We Magicians Still Alive in 2021", 5*60+30, 5),
                new Song("AREA 52", 4*60+38, 5),
                new Song("Kisaragi", 5*60+55, 5),
                new Song("Bermuda Triangle", 4*60, 5),
                new Song("CICADA3302", 7*60+16, 5),
                new Song("SLIME INCIDENT", 5*60+5, 5),
                new Song("The Cat Evolved Into The Microwave-proof Cat!", 3*60+48, 5),
                new Song("ZOMBIE CIRCUS", 4*60+4, 5),
                new Song("t / a/n / a/s / i/n / n", 3*60+24, 5),
                new Song("Purge My Existence Out Of This World", 5*60+9, 5),
                new Song("GHOUL", 4*60+31, 5),
                new Song("Myths You Forgot", 4*60+15, 5),
                new Song("ΩΩPARTS", 6*60+48, 5),
                new Song("Hello (BPM) 2021", 2*60+23, 5),
                new Song("THE MUZZLE FACING - Long muzzled version", 5*60+11, 5),
                new Song("#1f1e33 - #00102g version", 5*60+41, 5),
                new Song("Looking for Edge of Ground", 8*60+27, 5),

            };

            if (!context.Song.Any())
            {
                foreach (Song song in AllSongs)
                {
                    context.Add(song);
                }
            }
            await context.SaveChangesAsync();

            static List<SongContributor> InitializeSongContributors()
            {
                List<SongContributor> AllSongContibutors = new List<SongContributor>();

                List<int> crystallizedSongIds = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                foreach (int id in crystallizedSongIds)
                {
                    AllSongContibutors.Add(new SongContributor(1, id));
                }

                List<int> hanahataSongIds = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17 };
                foreach (int id in hanahataSongIds)
                {
                    AllSongContibutors.Add(new SongContributor(2, id));
                }

                List<int> figgieSongIds = new List<int> { 18, 19, 20, 21 };
                foreach (int id in figgieSongIds)
                {
                    AllSongContibutors.Add(new SongContributor(3, id));
                }

                List<int> geoxorSongIds = new List<int> { 22, 23, 24, 25, 26, 27, 28, 29, 30 };
                foreach (int id in geoxorSongIds)
                {
                    AllSongContibutors.Add(new SongContributor(4, id));
                }

                List<int> UUFOSongIds = new List<int>();
                for (int i = 0; i < 27; i++)
                {
                    UUFOSongIds.Add(i + 31);
                }
                foreach (int id in UUFOSongIds)
                {
                    AllSongContibutors.Add(new SongContributor(1, id));
                }

                return AllSongContibutors;
            }

            if (!context.SongContributor.Any())
            {
                List<SongContributor> list = InitializeSongContributors();
                foreach (SongContributor songContributor in list)
                {
                    context.Add(songContributor);
                }

            }
            await context.SaveChangesAsync();
            PlaylistSong[] PlaylistSongs = new PlaylistSong[]
            {
                new PlaylistSong(1, 1),
                new PlaylistSong(13, 1),
                new PlaylistSong(21, 1),
                new PlaylistSong(6,  1),
                new PlaylistSong(33, 1),
                new PlaylistSong(40, 1),
                new PlaylistSong(8,  1),
                new PlaylistSong(25, 1),
                new PlaylistSong(27, 1),
                new PlaylistSong(9,  1),
                new PlaylistSong(14, 1),
                new PlaylistSong(28, 2),
                new PlaylistSong(33, 2),
                new PlaylistSong(38, 2),
                new PlaylistSong(50, 2),
                new PlaylistSong(56, 2),
                new PlaylistSong(3,  2),
                new PlaylistSong(5,  2),
                new PlaylistSong(22, 3),
                new PlaylistSong(25, 3),
                new PlaylistSong(26, 3),
                new PlaylistSong(28, 3),
                new PlaylistSong(29, 3),
                new PlaylistSong(30, 3),
                new PlaylistSong(24, 3),
            };

            if (!context.PlaylistSong.Any())
            {
                foreach(PlaylistSong playlistSong in PlaylistSongs) 
                {
                    context.Add(playlistSong);
                }
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
