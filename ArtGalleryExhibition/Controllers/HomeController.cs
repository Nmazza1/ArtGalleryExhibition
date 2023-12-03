    using ArtGalleryExhibition.Data;
    using ArtGalleryExhibition.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;

    namespace ArtGalleryExhibition.Controllers
    {
        public class HomeController : Controller
        {
        
            private readonly ILogger<HomeController> _logger;

            private readonly ArtGalleryExhibitionContext _context;

            public HomeController(ArtGalleryExhibitionContext context, ILogger<HomeController> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<IActionResult> IndexAsync()
            {
            var viewModel = new HomePageViewModel
            {
                artists = await _context.Artist.ToListAsync(),
                artworks = await _context.ArtWork.ToListAsync(),
                exhibitions = await _context.Exhibition.ToListAsync()

            };

            return View(viewModel);
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }