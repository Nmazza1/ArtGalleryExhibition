using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
	public interface IOrderService
	{
		void PlaceOrder(Order order);
	}
}
