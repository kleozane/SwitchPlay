using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class PlatformRepository : BaseRepository<Platform>
    {
        private readonly SwitchPlayContext _context;

        public PlatformRepository(SwitchPlayContext context) : base(context) { _context = context; }
    }
}
