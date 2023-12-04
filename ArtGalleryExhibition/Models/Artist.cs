namespace ArtGalleryExhibition.Models
{
    public class Artist
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public bool isFeatured { get; set; }    

        public ICollection<ArtWork> Artworks { get; set; } = new List<ArtWork>();
        public int? ExhibitionID { get; set; }
    }
}
