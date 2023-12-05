using ArtGalleryExhibition.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryExhibition.Controllers
{
	public class ShopCartController : Controller
	{
		private IShopCartService cartService;
		private IArtWorkService artWorkService;

		public ShopCartController(IShopCartService cartService, IArtWorkService artWorkService)
		{
			this.cartService = cartService;
			this.artWorkService = artWorkService;
		}

		public IActionResult Index()
		{
			var items = cartService.GetCartItems();
			cartService.CartItems = items;
			ViewBag.CartTotal = cartService.GetCartTotal();
			return View(items);
		}

        //public IActionResult AddToCart(int ID)
        //{
        //    var artwork = artWorkService.GetAllArtWorks().FirstOrDefault(a => a.ID == ID);
        //    if (artwork != null)
        //    {
        //        int index = cartService.AddToCart(artwork); // Assuming AddToCart returns the index of the added item
        //        int cartCount = cartService.GetCartItems().Count();
        //        HttpContext.Session.SetInt32("CartCount", cartCount);

        //        // Optionally, you can pass the index as a route value to the Index action
        //        return RedirectToAction("Index", new { index = index });
        //    }

        //    // Handle the case where the artwork is not found
        //    return RedirectToAction("Index", "Home");
        //}

        public RedirectToActionResult AddToCart(int? ID)
        {

            var artwork = artWorkService.GetAllArtWorks().FirstOrDefault(a => a.ID == ID);
            if (artwork != null)
            {
                Console.WriteLine("INSIDE THE IF STATEMENT OF CONTROLLER CART");
                cartService.AddToCart(artwork);
                int cartCount = cartService.GetCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index", "ShopCart");
            ///	return View();
        }

        public RedirectToActionResult RemoveFromCart(int ID)
		{
			var artwork = artWorkService.GetAllArtWorks().FirstOrDefault(a => a.ID == ID);
			if (artwork != null)
			{
				cartService.RemoveFromCart(artwork);
				int cartCount = cartService.GetCartItems().Count;
				HttpContext.Session.SetInt32("CartCount", cartCount);
			}
			return RedirectToAction("Index");
		}
	}
}
