using ArtGalleryExhibition.Data;
using ArtGalleryExhibition.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryExhibition.Controllers
{
	[Authorize]
	public class OrdersController : Controller
	{
		private IOrderService orderService;
		private IShopCartService cartService;

		public OrdersController(IOrderService orderService, IShopCartService cartService)
		{
			this.orderService = orderService;
			this.cartService = cartService;
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			orderService.PlaceOrder(order);
			cartService.ClearCart();
			HttpContext.Session.SetInt32("CartCount", 0);
			return RedirectToAction("CheckoutComplete");
		}

		public IActionResult CheckoutComplete()
		{
			return View();
		}
	}
}
