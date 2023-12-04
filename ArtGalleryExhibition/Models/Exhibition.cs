using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ArtGalleryExhibition.Models
{
    public class Exhibition
    {

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public string? Address { get; set; }
        public bool currentlyRunning { get; set; }
        public ICollection<ArtWork>? works { get; set; } = new List<ArtWork>();
        public ICollection<Artist>? artists { get; set; } = new List<Artist>();

    }
}
