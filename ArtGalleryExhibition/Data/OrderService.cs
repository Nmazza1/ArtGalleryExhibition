using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
	public class OrderService : IOrderService
	{
		private ArtGalleryExhibitionContext dbContext;
		private IShopCartService cartService;

		public OrderService(ArtGalleryExhibitionContext dbContext, IShopCartService cartService)
		{
			this.dbContext = dbContext;
			this.cartService = cartService;
		}
		public void PlaceOrder(Order order)
		{
			var cartItems = cartService.GetCartItems();
			order.OrderDetails = new List<OrderDetail>();
			foreach (var cartItem in cartItems)
			{
				var orderDetail = new OrderDetail
				{
					ArtworkID = cartItem.Artwork.ID,
					Price = (decimal)cartItem.Artwork.Price
				};
				order.OrderDetails.Add(orderDetail);
			}
			order.OrderPlaced = DateTime.Now;
			order.OrderTotal = cartService.GetCartTotal();
			dbContext.Orders.Add(order);
			dbContext.SaveChanges();
		}
	}
}
