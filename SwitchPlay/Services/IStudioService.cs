using SwitchPlay.Data;

namespace SwitchPlay.Services
{
    public interface IStudioService
    {
        Task CreateStudioAsync(Studio studio);
        Task UpdateStudioAsync(Studio studio);
        Task DeleteStudioAsync(int id);
        Task<Studio> GetStudioAsync(int id);
        Task<IEnumerable<Studio>> GetAllStudiosAsync();
    }
}
