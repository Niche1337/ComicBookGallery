using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        //Connection string can be passed to base as well
        //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = ComicBookGallery; Integrated Security = True; MultipleActiveResultSets=True
        public Context() : base("ComicBookGallery")
        {
            Database.SetInitializer(new DatabaseIntitalizer());
        }

        //plural name is common convention
        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));

            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating)
                .HasPrecision(5,2);
        }

    }
}
