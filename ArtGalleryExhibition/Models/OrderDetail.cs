namespace ArtGalleryExhibition.Models
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public int ArtworkID { get; set; }
		public ArtWork? Artwork { get; set; }
		public int OrderId { get; set; }
		public Order? Order { get; set; }
		public decimal Price { get; set; }
	}
}
