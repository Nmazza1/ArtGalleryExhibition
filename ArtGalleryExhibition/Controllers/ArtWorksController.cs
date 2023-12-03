using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtGalleryExhibition.Data;
using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Controllers
{
    public class ArtWorksController : Controller
    {
        private readonly ArtGalleryExhibitionContext _context;

        public ArtWorksController(ArtGalleryExhibitionContext context)
        {
            _context = context;
        }

        // GET: ArtWorks
        public async Task<IActionResult> Index()
        {
              return _context.ArtWork != null ? 
                          View(await _context.ArtWork.ToListAsync()) :
                          Problem("Entity set 'ArtGalleryExhibitionContext.ArtWork'  is null.");
        }

        // GET: ArtWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            var artWork = await _context.ArtWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // GET: ArtWorks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Description,CompletionDate,ImageUrl")] ArtWork artWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artWork);
        }

        // GET: ArtWorks/Edit/5
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
            return View(artWork);
        }

        // POST: ArtWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Description,CompletionDate,ImageUrl")] ArtWork artWork)
        {
            if (id != artWork.Id)
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
                    if (!ArtWorkExists(artWork.Id))
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
            return View(artWork);
        }

        // GET: ArtWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            var artWork = await _context.ArtWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // POST: ArtWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
          return (_context.ArtWork?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
