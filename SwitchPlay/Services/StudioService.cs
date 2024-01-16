using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public class StudioService : IStudioService
    {
        private readonly StudioRepository _context;
        public StudioService(StudioRepository context)
        {
            _context = context;
        }

        public async Task CreateStudioAsync(Studio studio)
        {
            await _context.AddAsync(studio);
        }

        public async Task UpdateStudioAsync(Studio studio)
        {
            await _context.UpdateAsync(studio);
        }

        public async Task DeleteStudioAsync(int id)
        {
            await _context.RemoveAsync(id);
        }

        public async Task<Studio> GetStudioAsync(int id)
        {
            return await _context.GetAsync(id);
        }

        public async Task<IEnumerable<Studio>> GetAllStudiosAsync()
        {
            return await _context.GetAllAsync();
        }
    }
}
