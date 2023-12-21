using Microsoft.EntityFrameworkCore;

namespace SwitchPlay.Data
{
    public class SwitchPlayContext : DbContext
    {
        public SwitchPlayContext(DbContextOptions<SwitchPlayContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
    }
}
