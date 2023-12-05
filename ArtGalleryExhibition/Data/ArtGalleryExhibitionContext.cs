    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtGalleryExhibition.Models;

namespace ArtGalleryExhibition.Data
{
    public class ArtGalleryExhibitionContext : DbContext
    {
        public ArtGalleryExhibitionContext (DbContextOptions<ArtGalleryExhibitionContext> options)
            : base(options)
        {
        }

        public DbSet<ArtGalleryExhibition.Models.Artist> Artist { get; set; } = default!;

        public DbSet<ArtGalleryExhibition.Models.CartItem> CartItems { get; set; }
        
        public DbSet<ArtGalleryExhibition.Models.Order> Orders { get; set; }

        public DbSet<ArtGalleryExhibition.Models.OrderDetail> OrderDetails { get; set; }

        public DbSet<ArtGalleryExhibition.Models.ArtWork>? ArtWork { get; set; }

        public DbSet<ArtGalleryExhibition.Models.Exhibition>? Exhibition { get; set; }
    }
}
