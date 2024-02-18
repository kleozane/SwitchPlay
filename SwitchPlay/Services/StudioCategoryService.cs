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

        public async Task CreateStudioCategoryAsync(int studioId, int categoryId)
        {
            await _context.CreateStudioCategoryAsync(studioId, categoryId);
        }

        public async Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId)
        {
            return await _context.GetByStudioId(studioId);
        }
    }
}
