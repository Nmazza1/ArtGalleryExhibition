namespace ArtGalleryExhibition.Models
{
    public class CartItem
    {
        public int ArtworkId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public CartItem(int artworkId, string title, decimal price)
        {
            ArtworkId = artworkId;
            Title = title;
            Price = price;
        }
    }


}
