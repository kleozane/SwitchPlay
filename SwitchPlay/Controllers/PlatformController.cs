using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Models;
using SwitchPlay.Services;

namespace SwitchPlay.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        public async Task<IActionResult> Index()
        {
            var platforms = await _platformService.GetAllPlatformsAsync();
            return View(platforms);
        }

    }
}
