using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public class GameService : IGameService
    {
        private readonly GameRepository _context;
        public GameService(GameRepository context)
        {
            _context = context;
        }

        public async Task CreateGameAsync(Game game)
        {
            await _context.AddAsync(game);
        }

        public async Task UpdateGameAsync(Game game)
        {
            await _context.UpdateAsync(game);
        }

        public async Task DeleteGameAsync(int id)
        {
            await _context.RemoveAsync(id);
        }

        public async Task<Game> GetGameAsync(int id)
        {
            return await _context.GetAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.GetAllAsync();
        }
    }
}
