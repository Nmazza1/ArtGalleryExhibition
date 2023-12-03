namespace ArtGalleryExhibition.Models
{
    public class CreateExhibitionViewModel
    {

        public Exhibition? Exhibition { get; set; } = new Exhibition();

        public List<ArtWork> passedArtworks { get; set; } = new List<ArtWork>();
        public List <Artist> passedArtists { get; set; } = new List<Artist>();

        // Arrays for selected artist and artwork IDs
        public int[] SelectedArtworkIds { get; set; } = new int[0];
        public int[] SelectedArtistIds { get; set; } = new int[0];
    }
}
