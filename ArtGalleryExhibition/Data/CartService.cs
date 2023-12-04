using ArtGalleryExhibition.Models;
using Newtonsoft.Json;

namespace ArtGalleryExhibition.Data
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CartItem> GetCart()
        {
            var cartCookie = _httpContextAccessor.HttpContext?.Request.Cookies["Cart"];

            if (cartCookie != null)
            {
                var cart = JsonConvert.DeserializeObject<List<CartItem>>(cartCookie);
                return cart ?? new List<CartItem>();
            }

            return new List<CartItem>();
        }


        public void AddToCart(int artworkId, string title, decimal price)
        {
            var cart = GetCart();

            var newItem = new CartItem(artworkId, title, price);   

            cart.Add(newItem);
            SaveCart(cart);
        }

        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Cart", cartJson);
        }
    }
}
