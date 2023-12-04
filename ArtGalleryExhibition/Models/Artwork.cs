namespace ArtGalleryExhibition.Models
{
    public class ArtWork
    {
        public int ID { get; set; }

        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? CompletionDate { get; set; }
        public string? ImageUrl { get; set; }
        public bool? isFeatured { get; set; } = false;
        
        public int? ArtistID { get; set; }

    }
}
