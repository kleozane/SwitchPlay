using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class StudioRepository : BaseRepository<Studio>
    {
        private readonly SwitchPlayContext _context;

        public StudioRepository(SwitchPlayContext context) : base(context) { _context = context; }
    }
}
