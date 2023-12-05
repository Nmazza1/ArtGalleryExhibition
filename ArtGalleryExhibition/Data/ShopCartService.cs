using ArtGalleryExhibition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ArtGalleryExhibition.Data
{
    public class ShopCartService : IShopCartService
    {
        private ArtGalleryExhibitionContext dbContext;

        public ShopCartService(ArtGalleryExhibitionContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CartItem>? CartItems { get; set; }
        public string? CartId { get; set; }

        public static ShopCartService GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ArtGalleryExhibitionContext context = services.GetService<ArtGalleryExhibitionContext>() ?? throw new Exception("Error initializing ArtGallery db context");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShopCartService(context) { CartId = cartId };
        }

        public void AddToCart(ArtWork artwork)
        {
            var cartItem = dbContext.CartItems.FirstOrDefault(s => s.Artwork.ID == artwork.ID && s.CartId == CartId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Artwork = artwork,
                };
                dbContext.CartItems.Add(cartItem);
            }
        }

        //public void AddToCart(int ID, string Title, decimal Price)
        //{
        //    throw new NotImplementedException();
        //}

        public void ClearCart()
        {
            var cartItems = dbContext.CartItems.Where(s => s.CartId == CartId);
            dbContext.CartItems.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }

        //public List<CartItem> GetCartItems()
        //{
        //    /*Console.Write(dbContext.CartItems.Where(s => s.CartId == CartId).Include(a => a.Artwork).ToList());
        //    return CartItems ??= dbContext.CartItems.Where(s => s.CartId == CartId).Include(a => a.Artwork).ToList();*/
            
        //}

        public List<CartItem> GetCartItems()
        {
            var cartItems = dbContext.CartItems.Include(b => b.Artwork).ToList();
          //  var cartItems = dbContext.CartItems
       //   cartItems
       //.Where(s => s.CartId == CartId)
       //.Include(a => a.Artwork)
       //.ToList();

            // Log the cart items to the console
            Console.WriteLine("Cart Items:");
            foreach (var cartItem in cartItems)
            {
                Console.WriteLine($"CartItem Id: {cartItem.Id}, Cart Id: {cartItem.CartId}");
                if (cartItem.Artwork != null)
                {
                    Console.WriteLine($"Artwork Id: {cartItem.Artwork.ID}, Artwork Title: {cartItem.Artwork.Title}");
                }
                else
                {
                    Console.WriteLine("Artwork is null");
                }
            }

            // Optionally return the cart items
            return cartItems;
            //var cartItems = dbContext.CartItems.Where(s => s.CartId == CartId).Include(a => a.Artwork).ToList();

            //// Log the cart items to the console
            //Console.WriteLine("Cart Items:");
            //foreach (var cartItem in cartItems)
            //{
            //    Console.WriteLine($"CartItem Id: {cartItem.Id}, Cart Id: {cartItem.CartId}");
            //}

            //// Optionally return the cart items
            //return cartItems;
        }


        public decimal GetCartTotal()
        {
            decimal totalCost = dbContext.CartItems
                .Where(s => s.CartId == CartId && s.Artwork != null)
                .Sum(s => s.Artwork.Price) != null ?
                dbContext.CartItems
                    .Where(s => s.CartId == CartId && s.Artwork != null)
                    .Sum(s => s.Artwork.Price) :
                0m;

            return totalCost;
        }




        //public decimal GetCartTotal()
        //{
        //    Decimal totalPrices = dbContext.CartItems.Where(s => s.CartId == CartId)
        //        .Select(s => s.Artwork.Price);
        //    Decimal totalCost = 0.0;
        //    if(totalPrices.Any())
        //    {
        //        foreach (var price in totalPrices)
        //        {
        //            totalCost += totalPrices; 
        //        }
        //    }
        //    return (decimal)totalCost;
        //}

        public void RemoveFromCart(ArtWork artWork)
        {
            var cartItem = dbContext.CartItems.FirstOrDefault(s => s.Artwork.ID == artWork.ID && s.CartId == CartId);

            if (cartItem != null)
            {
                dbContext.CartItems.Remove(cartItem);
            }
            dbContext.SaveChanges();

        }
    }
}
