using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public class GamePlatformService : IGamePlatformService
    {
        private readonly GamePlatformRepository _context;
        public GamePlatformService(GamePlatformRepository context)
        {
            _context = context;
        }

        public async Task CreateGamePlatformAsync(int gameId, List<int> platformIds)
        {
            await _context.CreateGamePlatformAsync(gameId, platformIds);
        }

        public async Task<IEnumerable<GamePlatform>> GetByGameId(int gameId)
        {
            return await _context.GetByGameId(gameId);
        }
    }
}
