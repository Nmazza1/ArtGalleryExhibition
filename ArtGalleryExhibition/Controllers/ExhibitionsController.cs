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
    public class ExhibitionsController : Controller
    {
        private readonly ArtGalleryExhibitionContext _context;

        public ExhibitionsController(ArtGalleryExhibitionContext context)
        {
            _context = context;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public async Task<IActionResult> CreateAsync()
        {
            var exhibition = new  Exhibition();
            var viewModel = new CreateExhibitionViewModel
            {
                Exhibition = exhibition,
                ArtWorks = await _context.ArtWork.ToArrayAsync(),
                Artists = await _context.Artist.ToArrayAsync()
                // Other properties initialization here
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExhibitionViewModel viewModel)
        {
            try
            {
                Console.WriteLine("Create method started");
                var toPostExhibition = new Exhibition
                {
                    ArtWorks = new List<ArtWork>(),
                    Artists = new List<Artist>()
                };
                //       if (ModelState.IsValid)
                //     {
                Console.WriteLine("ModelState is valid");

                   
                    toPostExhibition.StartDate = viewModel.Exhibition.StartDate;
                    toPostExhibition.EndDate = viewModel.Exhibition.EndDate;
                    toPostExhibition.Address = viewModel.Exhibition.Address;
                    toPostExhibition.currentlyRunning = viewModel.Exhibition.currentlyRunning;

                Console.WriteLine(viewModel.SelectedArtworkIds);
                Console.WriteLine(viewModel.SelectedArtistIds);
                foreach (var artId in viewModel.SelectedArtworkIds)
                {
                    var artWork = _context.ArtWork.FirstOrDefault(a => a.Id == artId);

                    if (artWork != null)
                    {
                        toPostExhibition.ArtWorks.Add(artWork);
                    }
                }


                foreach (var artistId in viewModel.SelectedArtistIds)
                    {
                        var artist = _context.Artist.FirstOrDefault(a => a.Id == artistId);

                        if(artist != null)
                        {
                          toPostExhibition.Artists.Add(artist);
                        }
                    }
                    _context.Add(toPostExhibition);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Index");
               // }

               // return RedirectToAction("Create");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Create method: {ex}");
                throw; // Rethrow the exception for proper logging
            }
        }

        // GET: Exhibitions/Edit/5
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Address,currentlyRunning")] Exhibition exhibition)
        {
            if (id != exhibition.Id)
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
                    if (!ExhibitionExists(exhibition.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exhibition == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
          return (_context.Exhibition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
