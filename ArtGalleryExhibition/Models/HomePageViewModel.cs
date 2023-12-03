namespace ArtGalleryExhibition.Models
{
    public class HomePageViewModel
    {

        public IEnumerable<ArtWork> artworks { get; set; }
        public IEnumerable<Artist> artists { get; set; }
        public IEnumerable<Exhibition> exhibitions { get; set; }
    }
}
