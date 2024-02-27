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
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }

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

            // Lidhja e Kategorive me Studiot N-N

            builder.Entity<StudioCategory>().HasKey(e => new { e.CategoryId, e.StudioId });

            builder.Entity<StudioCategory>()
                .HasOne(sc => sc.Studio)
                .WithMany(s => s.StudioCategories)
                .HasForeignKey(sc => sc.StudioId);

            builder.Entity<StudioCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.StudioCategories)
                .HasForeignKey(sc => sc.CategoryId);

            // Lidhja e Lojerave me Kategorite N-N

            builder.Entity<GameCategory>().HasKey(e => new { e.CategoryId, e.GameId });

            builder.Entity<GameCategory>()
                .HasOne(sc => sc.Game)
                .WithMany(s => s.GameCategories)
                .HasForeignKey(sc => sc.GameId);

            builder.Entity<GameCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.GameCategories)
                .HasForeignKey(sc => sc.CategoryId);



            // Lidhja e Lojerave me Platformat N-N

            builder.Entity<GamePlatform>().HasKey(e => new { e.PlatformId, e.GameId });

            builder.Entity<GamePlatform>()
                .HasOne(sc => sc.Game)
                .WithMany(s => s.GamePlatforms)
                .HasForeignKey(sc => sc.GameId);

            builder.Entity<GamePlatform>()
                .HasOne(sc => sc.Platform)
                .WithMany(c => c.GamePlatforms)
                .HasForeignKey(sc => sc.PlatformId);


            // Lidhja e Lojerave me Studion N-1

            builder.Entity<Game>()
                .HasOne(g => g.Studio)
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.StudioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
       
    }
}
