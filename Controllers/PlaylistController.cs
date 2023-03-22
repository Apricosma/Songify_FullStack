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
    public class PlaylistController : Controller
    {
        private readonly SongifyContext _context;

        public PlaylistController(SongifyContext context)
        {
            _context = context;
        }

        // GET: Playlist
        public async Task<IActionResult> Index()
        {
            var songifyContext = _context.Playlist.Include(p => p.User)
                .Include(s => s.PlaylistSongs);
            return View(await songifyContext.ToListAsync());
        }

        public async Task<IActionResult> RemoveFromPlaylist(int songId, int playlistId)
        {
            var playlist = await _context.Playlist.FindAsync(playlistId);

            if(playlist == null)
            {
                return NotFound();
            }

            var selectedSong = await _context.PlaylistSong
                .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);

            if (selectedSong == null)
            {
                return NotFound();
            }

            _context.PlaylistSong.Remove(selectedSong);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = playlistId });
        }

        // GET: Playlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = _context.Playlist
                .Include(p => p.PlaylistSongs)
                    .ThenInclude(ps => ps.Song)
                    .ThenInclude(s => s.Album)
                .Include(p => p.PlaylistSongs)
                    .ThenInclude(ps => ps.Song)
                    .ThenInclude(s => s.Contributors)
                    .ThenInclude(sc => sc.Artist)
                .Where(p => p.Id == id).ToList();

            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // GET: Playlist/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Playlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, UserId")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var newPlaylist = new Playlist(playlist.Name, playlist.UserId);
                _context.Add(newPlaylist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", playlist.UserId);
            return View(playlist);
        }

        // GET: Playlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", playlist.UserId);
            return View(playlist);
        }

        // POST: Playlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", playlist.UserId);
            return View(playlist);
        }

        // GET: Playlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlist == null)
            {
                return Problem("Entity set 'SongifyContext.Playlist'  is null.");
            }
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlist.Remove(playlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
          return _context.Playlist.Any(e => e.Id == id);
        }
    }
}
