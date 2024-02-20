using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public class StudioCategoryService : IStudioCategoryService
    {
        private readonly StudioCategoryRepositories _context;
        public StudioCategoryService(StudioCategoryRepositories context)
        {
            _context = context;
        }

        public async Task CreateStudioCategoryAsync(int studioId, List<int> categoryIds)
        {
            await _context.CreateStudioCategoryAsync(studioId, categoryIds);
        }

        public async Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId)
        {
            return await _context.GetByStudioId(studioId);
        }
    }
}
