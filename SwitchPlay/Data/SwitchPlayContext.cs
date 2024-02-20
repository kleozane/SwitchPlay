using Microsoft.EntityFrameworkCore;

namespace SwitchPlay.Data
{
    public class SwitchPlayContext : DbContext
    {
        public SwitchPlayContext(DbContextOptions<SwitchPlayContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<StudioCategory> StudioCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 1,
                Name = "PC",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 2,
                Name = "Playstation",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 3,
                Name = "Xbox",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 4,
                Name = "Nintendo",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 5,
                Name = "Mobile",
            });



            builder.Entity<StudioCategory>().HasKey(e => new { e.CategoryId, e.StudioId });

            builder.Entity<StudioCategory>()
                .HasOne(sc => sc.Studio)
                .WithMany(s => s.StudioCategories)
                .HasForeignKey(sc => sc.StudioId);

            builder.Entity<StudioCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.StudioCategories)
                .HasForeignKey(sc => sc.CategoryId);
        }
       
    }
}
