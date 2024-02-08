using SwitchPlay.Data;

namespace SwitchPlay.Services
{
    public interface IGameService
    {
        Task CreateGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task<Game> GetGameAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync();
    }
}
