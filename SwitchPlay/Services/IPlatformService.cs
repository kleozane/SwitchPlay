using SwitchPlay.Data;

namespace SwitchPlay.Services
{
    public interface IPlatformService
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    }
}
