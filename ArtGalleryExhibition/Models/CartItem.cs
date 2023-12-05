namespace ArtGalleryExhibition.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public ArtWork? Artwork { get; set; }
        public string? CartId { get; set; }

        public CartItem (int id, ArtWork? artwork, string? cartId)
        {
            Id = id;
            Artwork = artwork;
            CartId = cartId;
        }

        public CartItem (int id, ArtWork? artwork)
        {
            Id= id;
            Artwork = artwork;
        }
        public CartItem()
        {

        }
    }


}
