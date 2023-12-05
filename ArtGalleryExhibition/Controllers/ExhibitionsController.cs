using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtGalleryExhibition.Data;
using ArtGalleryExhibition.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace ArtGalleryExhibition.Controllers
{
    public class ExhibitionsController : Controller
    {
        private readonly ArtGalleryExhibitionContext _context;
        private readonly IShopCartService _cartService;

        public ExhibitionsController(ArtGalleryExhibitionContext context, IShopCartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddSelectedArtworksToCart([FromForm] List<int> selectedArtworkIds, int exhibitionId)

        {
            Console.WriteLine($"Exhibition ID: {exhibitionId}");
            Console.WriteLine("Selected Artwork ID's: " + string.Join(", ", selectedArtworkIds));

            // Assuming you have a method to get artworks by IDs
            var chosenArts = new List<CartItem>();
            foreach(var artId in selectedArtworkIds)
            {
              var artwork =  _context.ArtWork.FirstOrDefault(m => m.ID == artId);
                chosenArts.Add(new CartItem(artwork.ID, artwork));
            }
            var selectedArtworks = _context.ArtWork
                .Where(artwork => selectedArtworkIds.Contains(artwork.ID))
                .ToList();

            foreach (var artwork in selectedArtworks)
            {
                //  _cartService.AddToCart(artwork.ID, artwork.Title, (decimal)artwork.Price);
                _cartService.AddToCart(artwork);
            }

            // Log the current cart to the console
            Console.WriteLine("Current Cart:");
            var currentCart = _cartService.GetCartItems();
            foreach (var item in currentCart)
            {
                Console.WriteLine($"Artwork ID: {item.Artwork.ID}, Title: {item.Artwork.Title}, Price: {item.Artwork.Price}");
            }

            // Redirect back to the exhibition details page or wherever appropriate
            return RedirectToAction("Details", new { id = exhibitionId });
        }


        // GET: Exhibitions
        public async Task<IActionResult> Index()
        {
              return _context.Exhibition != null ? 
                          View(await _context.Exhibition.ToListAsync()) :
                          Problem("Entity set 'ArtGalleryExhibitionContext.Exhibition'  is null.");
        }

        // GET: Exhibitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exhibition == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition
                .Include(m => m.works)
                .Include(m => m.artists)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exhibitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,Name,StartDate,EndDate,Address,currentlyRunning")] Exhibition exhibition)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid: " + JsonConvert.SerializeObject(exhibition, Formatting.Indented));
                return View("Create", exhibition);
            }

            if (ModelState.IsValid)
            {
                _context.Add(exhibition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhibition);
        }

        // GET: Exhibitions/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exhibition == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartDate,EndDate,Address,currentlyRunning")] Exhibition exhibition)
        {
            if (id != exhibition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionExists(exhibition.ID))
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
            return View(exhibition);
        }

        // GET: Exhibitions/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exhibition == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exhibition == null)
            {
                return Problem("Entity set 'ArtGalleryExhibitionContext.Exhibition'  is null.");
            }
            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition != null)
            {
                _context.Exhibition.Remove(exhibition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitionExists(int id)
        {
          return (_context.Exhibition?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
