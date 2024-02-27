using Microsoft.EntityFrameworkCore;
using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class GamePlatformRepository : BaseRepository<Platform>
    {

        private readonly SwitchPlayContext _context;
        public GamePlatformRepository(SwitchPlayContext context) : base(context) { _context = context; }


        public async Task CreateGamePlatformAsync(int studioId, List<int> platformIds)
        {
            var sc = await _context.GamePlatforms.ToListAsync();
            _context.RemoveRange(sc);

            if (platformIds != null)
            {
                foreach (var id in platformIds)
                {
                    _context.Add(new GamePlatform
                    {
                        GameId = studioId,
                        PlatformId = id
                    });

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<GamePlatform>> GetByGameId(int studioId)
        {
            return await _context.GamePlatforms.Where(i => i.GameId == studioId).Include(a => a.Platform).ToListAsync();
        }
    }
}
