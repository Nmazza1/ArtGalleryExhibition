using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtGalleryExhibition.Data;
using ArtGalleryExhibition.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArtGalleryExhibition.Controllers
{
    public class ArtWorksController : Controller
    {
        private readonly ArtGalleryExhibitionContext _context;
      //  private IArtWorkService artWorkService; 

        public ArtWorksController(ArtGalleryExhibitionContext context/*, IArtWorkService artWorkService*/)
        {
            _context = context;
            //artWorkService = artWorkService;
        }

        // GET: ArtWorks
        public async Task<IActionResult> Index()
        {
            return _context.ArtWork != null ?
                           View(await _context.ArtWork.ToListAsync()) :
                        Problem("Entity set 'ArtGalleryExhibitionContext.ArtWork'  is null.");
            //   return View(artWorkService.GetAllArtWorks());
        }

        // GET: ArtWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            var artWork = await _context.ArtWork
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // GET: ArtWorks/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            PopulateExhibitionsDropDownList();
            PopulateArtistDropDownList();
            return View();
        }

        // POST: ArtWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,Title,Price,Description,CompletionDate,ImageUrl,ExhibitionID")] ArtWork artWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateExhibitionsDropDownList();
            PopulateArtistDropDownList();
            return View(artWork);
        }

        // GET: ArtWorks/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            var artWork = await _context.ArtWork.FindAsync(id);
            if (artWork == null)
            {
                return NotFound();
            }
            PopulateArtistDropDownList();
            return View(artWork);
        }

        // POST: ArtWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Price,Description,CompletionDate,ImageUrl,ExhibitionID")] ArtWork artWork)
        {
            if (id != artWork.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtWorkExists(artWork.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateExhibitionsDropDownList();
                PopulateArtistDropDownList();
                return RedirectToAction(nameof(Index));
            }
            return View(artWork);
        }

        // GET: ArtWorks/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            var artWork = await _context.ArtWork
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // POST: ArtWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtWork == null)
            {
                return Problem("Entity set 'ArtGalleryExhibitionContext.ArtWork'  is null.");
            }
            var artWork = await _context.ArtWork.FindAsync(id);
            if (artWork != null)
            {
                _context.ArtWork.Remove(artWork);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtWorkExists(int id)
        {
          return (_context.ArtWork?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        private void PopulateExhibitionsDropDownList()
        {
            var exhibitionsQuery = from d in _context.Exhibition
                                   orderby d.Name
                                   select d;
            Console.WriteLine("Executed Exhibition Query");
            Console.Write(exhibitionsQuery);
            ViewBag.ExhibitionID = new SelectList(exhibitionsQuery, "ID", "Name");
        }
        private void PopulateArtistDropDownList()
        {
            var artworksQuery = from d in _context.Artist
                                orderby d.Name
                                select d;
            ViewBag.ArtistID = new SelectList(artworksQuery, "ID", "Name");
        }
    }
}
