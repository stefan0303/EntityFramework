using BookShopSystem.Models;

namespace BookShopSystem.Data
{
    using System.Data.Entity;

    public class BookShopContext : DbContext
    {

        public BookShopContext()
            : base("name=BookShopContext")
        {

        }
        
        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b=>b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedId");
                    m.ToTable("RelatedBooks");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}