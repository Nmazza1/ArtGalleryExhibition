using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
    public interface IShopCartService
    {
        void AddToCart(ArtWork artwork);
      //  void AddToCart(int ID, string Title, decimal Price);
        void RemoveFromCart(ArtWork artwork);
        List<CartItem> GetCartItems();
        void ClearCart();
        decimal GetCartTotal();
        public List<CartItem> CartItems { get; set; }
    }
}
