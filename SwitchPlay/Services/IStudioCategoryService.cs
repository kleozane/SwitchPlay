using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public interface IStudioCategoryService
    {
        Task CreateStudioCategoryAsync(int studioId, List<int> categoryIds);
        Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId);
    }
}
