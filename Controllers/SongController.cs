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
    public class SongController : Controller
    {
        private readonly SongifyContext _context;

        public SongController(SongifyContext context)
        {
            _context = context;
        }

        // GET: Song
        public async Task<IActionResult> Index()
        {
            var songifyContext = _context.Song
                .Include(s => s.Album)
                .Include(s => s.SongContributors)
                .ThenInclude(s => s.Artist);

            var playlists = await _context.Playlist.ToListAsync();
            ViewBag.Playlists = new SelectList(playlists, "Id", "Name");
            return View(await songifyContext.ToListAsync());
        }

        // GET: Song/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        private bool SongExists(int id)
        {
          return _context.Song.Any(e => e.Id == id);
        }
    }
}
