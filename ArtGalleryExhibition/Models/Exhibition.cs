using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ArtGalleryExhibition.Models
{
    public class Exhibition
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a start date.")]
        public string? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a end date.")]
        public string? EndDate { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Please specify if it's running currently.")]
        public bool currentlyRunning { get; set; }

        [Required(ErrorMessage = "Error with the Artworks.")]
        public List<ArtWork>? ArtWorks { get; set; } = new List<ArtWork>();
        [Required(ErrorMessage = "Error with the Artists.")]
        public List<Artist>? Artists { get; set; } = new List<Artist>();
    }
}
