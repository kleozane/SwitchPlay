using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public interface IStudioCategoryService
    {
        Task CreateStudioCategoryAsync(int studioId, int categoryId);
        Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId);
    }
}
