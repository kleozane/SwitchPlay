using SwitchPlay.Data;

namespace SwitchPlay.Services
{
    public interface IGameCategoryService
    {
        Task CreateGameCategoryAsync(int gameId, List<int> categoryIds);
        Task<IEnumerable<GameCategory>> GetByGameId(int gameId);
    }
}
