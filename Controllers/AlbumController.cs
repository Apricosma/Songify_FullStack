using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Songify_FullStack.Data;
using Songify_FullStack.Models;

namespace Songify_FullStack.Controllers
{
    public class AlbumController : Controller
    {
        private readonly SongifyContext _context;

        public AlbumController(SongifyContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            var albums = await _context.Album
                .Include(s => s.Songs)
                .ThenInclude(sc => sc.Contributors)
                .ThenInclude(a => a.Artist)
                .ToListAsync();

            return View(albums);
        }

        [HttpPost]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId, int albumId)
        {
            // make sure they're in the db
            Playlist playlist = await _context.Playlist.FindAsync(playlistId);
            Song song = await _context.Song.FindAsync(songId);
            if (playlist == null || song == null)
            {
                return NotFound();
            }

            if (_context.PlaylistSong.Any(ps => ps.PlaylistId == playlistId && ps.SongId == songId))
            {
                // song already exists in selected playlist...
                ViewBag.ErrorMessage = "Song already exists in playlist";

                return RedirectToAction("Details", "Album", new { id = albumId });
            }

            PlaylistSong playlistSong = new PlaylistSong(songId, playlistId);
            _context.PlaylistSong.Add(playlistSong);

            await _context.SaveChangesAsync();

            // return to the same album
            return RedirectToAction("Details", "Album", new { id = albumId });
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            var albumDetailContext = _context.Song
            .Include(s => s.Album)
            .Include(s => s.Contributors)
            .ThenInclude(s => s.Artist)
            .Where(a => a.Album.Id == id);

            var playlists = await _context.Playlist.ToListAsync();
            ViewBag.Playlists = new SelectList(playlists, "Id", "Name");

            return View(albumDetailContext);
        }

        private bool AlbumExists(int id)
        {
          return _context.Album.Any(e => e.Id == id);
        }
    }
}
