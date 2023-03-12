using Microsoft.EntityFrameworkCore;
using Songify_FullStack.Data;

namespace Songify_FullStack.Models
{
    public class Seed
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new SongifyContext(serviceProvider.GetRequiredService<DbContextOptions<SongifyContext>>());

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

            Artist artistOne = new Artist("Camellia");
            if (!context.Artist.Any())
            {
                context.Artist.Add(artistOne);
            }
            await context.SaveChangesAsync();

            Album albumOne = new Album("crystallized");
            if (!context.Album.Any())
            {
                context.Album.Add(albumOne);
            }
            await context.SaveChangesAsync();

            Song songOne = new Song("Rain of Amethyst", 441, 1);
            if (!context.Song.Any())
            {
                context.Song.Add(songOne);
            }
            await context.SaveChangesAsync();

            SongContributor songContributorOne = new SongContributor(1, 1);
            if (!context.SongContributor.Any())
            {
                context.SongContributor.Add(songContributorOne);
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
