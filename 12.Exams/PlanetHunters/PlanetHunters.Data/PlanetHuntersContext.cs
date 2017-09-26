namespace PlanetHunters.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class PlanetHuntersContext : DbContext
    {
        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PlanetHuntersContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>().Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Astronomer>().Property(a => a.LastName).HasMaxLength(50).IsRequired();


            modelBuilder.Entity<Discovery>().Property(d => d.DateMade).HasColumnType("date");

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Pioneers)
                .WithMany(a => a.PioneeringDiscoveries)
                .Map(da =>
                {
                    da.ToTable("Pioneers");
                    da.MapLeftKey("DiscoveryId");
                    da.MapRightKey("AstronomerId");
                });

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Observers)
                .WithMany(a => a.ObservedDiscoveries)
                .Map(da =>
                {
                    da.ToTable("Observers");
                    da.MapLeftKey("DiscoveryId");
                    da.MapRightKey("AstronomerId");
                });

            modelBuilder.Entity<Telescope>().Property(t => t.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Telescope>().Property(t => t.Location).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<StarSystem>().Property(ss => ss.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<Star>().Property(s => s.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<Planet>().Property(p => p.Name).HasMaxLength(255).IsRequired();
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
    }
}