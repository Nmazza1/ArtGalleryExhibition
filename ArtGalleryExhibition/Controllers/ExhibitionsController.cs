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
using System.Security.Cryptography;

namespace ArtGalleryExhibition.Controllers
{
    public class ExhibitionsController : Controller
    {
        private ArtGalleryExhibitionContext _context;
        Random randomNum = new Random();
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
            var exhibition = new CreateExhibitionViewModel()
            {
                Exhibition = new Exhibition(),
                passedArtworks = await _context.ArtWork.ToListAsync(),
                passedArtists = await _context.Artist.ToListAsync()
            };

            return View(exhibition);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExhibitionViewModel viewModel)
        {
            Console.WriteLine($"Initial ViewModel: {JsonConvert.SerializeObject(viewModel)}");
            var toPostExhibition = new Exhibition();
            toPostExhibition.StartDate = viewModel.Exhibition.StartDate;
            toPostExhibition.EndDate = viewModel.Exhibition.EndDate;
            toPostExhibition.Address = viewModel.Exhibition.Address;
            toPostExhibition.currentlyRunning = viewModel.Exhibition.currentlyRunning;
            foreach(var artId in viewModel.SelectedArtworkIds)
            {
                var artWork = _context.ArtWork.FirstOrDefault(a => a.Id == artId);

                if (artWork != null)
                {
                    toPostExhibition.ArtWorks.Add(artWork);
                }
                toPostExhibition.ArtWorks.Add(artWork);
            }
            foreach (var artistId in viewModel.SelectedArtistIds)
            {
                var artist = _context.Artist.FirstOrDefault(a => a.Id == artistId);

                if (artist != null)
                {
                    toPostExhibition.Artists.Add(artist);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine($"Posting ViewModel: {JsonConvert.SerializeObject(toPostExhibition)}");
                    _context.Add(toPostExhibition);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in Create method: {ex}");
                    throw; // Rethrow the exception for proper logging
                }
            }
            else
            {
                Console.WriteLine($"Received ViewModel on Error: {JsonConvert.SerializeObject(viewModel)}");
                return RedirectToAction("Create");
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
