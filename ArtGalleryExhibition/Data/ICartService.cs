using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
    public interface ICartService
    {
        List<CartItem> GetCart();
        void AddToCart(int artworkId, string title, decimal price);
    }
}
