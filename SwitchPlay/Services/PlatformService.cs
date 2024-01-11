using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly PlatformRepository _context;
        public PlatformService(PlatformRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _context.GetAllAsync();
        }
    }
}
