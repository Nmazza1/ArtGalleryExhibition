namespace ArtGalleryExhibition.Models
{
    public class ArtWork
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CompletionDate { get; set; }
        public string ImageUrl { get; set; }

    }
}
