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
        }
       
    }
}
