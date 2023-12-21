using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class CategeoryRepository : BaseRepository<Category>
    {

        private readonly SwitchPlayContext _context;

        public CategeoryRepository(SwitchPlayContext context) : base(context) { _context = context; }
    }
}
