using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
	public class ArtWorkService : IArtWorkService
	{
		private ArtGalleryExhibitionContext dbContext;

		public ArtWorkService( ArtGalleryExhibitionContext dbContext )
		{
			this.dbContext = dbContext;
		}

		public IEnumerable<ArtWork> GetAllArtWorks()
		{
			return dbContext.ArtWork;
		}

		public ArtWork? GetArtWorkDetail( int id )
		{
			return dbContext.ArtWork.FirstOrDefault(p => p.ID == id);
		}
	}
}
