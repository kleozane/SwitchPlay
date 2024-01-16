using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Models;
using SwitchPlay.Services;

namespace SwitchPlay.Controllers
{
    public class StudioController : Controller
    {
        private readonly IStudioService _studioService;

        public StudioController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        public async Task<IActionResult> Index()
        {
            var studios = await _studioService.GetAllStudiosAsync();
            return View(studios);
        }

        public async Task<IActionResult> Add()
        {
            var model = new StudioForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudioForCreation model)
        {
            //var file = HttpContext.Request.Form.Files.FirstOrDefault();

            var studio = new Studio
            {
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo
            };

            await _studioService.CreateStudioAsync(studio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var studio = await _studioService.GetStudioAsync(id);
            var model = new StudioForModification();

            model.Id = studio.Id;
            model.Name = studio.Name;
            model.Description = studio.Description;
            model.Logo = studio.Logo;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudioForModification model)
        {
            var studio = await _studioService.GetStudioAsync(model.Id);

            studio.Name = model.Name;
            studio.Description = model.Description;
            studio.Logo = model.Logo;

            await _studioService.UpdateStudioAsync(studio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var studio = await _studioService.GetStudioAsync(id);
            await _studioService.DeleteStudioAsync(studio.Id);
            return RedirectToAction("Index");
        }
    }
}
