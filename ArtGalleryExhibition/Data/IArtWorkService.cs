using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
	public interface IArtWorkService
	{
		IEnumerable<ArtWork> GetAllArtWorks();
		ArtWork? GetArtWorkDetail(int id);
	}
}
