namespace ArtGalleryExhibition.Models
{
    public class CreateExhibitionViewModel
    {

        public Exhibition? Exhibition { get; set; } = null;
        public IEnumerable<ArtWork>? ArtWorks { get; set; } = null;
        public IEnumerable<Artist>? Artists { get; set; } = null;

        // Arrays for selected artist and artwork IDs
        public int[] SelectedArtworkIds { get; set; } = new int[0];
        public int[] SelectedArtistIds { get; set; } = new int[0];
    }
}
