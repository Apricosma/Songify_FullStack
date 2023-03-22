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
    public class ArtistController : Controller
    {
        private readonly SongifyContext _context;

        public ArtistController(SongifyContext context)
        {
            _context = context;
        }

        // GET: Artist
        public async Task<IActionResult> Index()
        {
            var artists = await _context.Artist
                .Include(sc => sc.Contributors)
                .ThenInclude(s => s.Song)
                .ThenInclude(a => a.Album)
                .ToListAsync();

            return View(artists);
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .Include(a => a.Contributors)
                .ThenInclude(sc => sc.Song)
                .ThenInclude(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }
        private bool ArtistExists(int id)
        {
          return _context.Artist.Any(e => e.Id == id);
        }
    }
}
