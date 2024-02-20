using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Migrations;
using SwitchPlay.Models;
using SwitchPlay.Services;

namespace SwitchPlay.Controllers
{
    public class StudioController : Controller
    {
        private readonly IStudioService _studioService;
        private readonly ICategoryService _categoryService;
        private readonly IStudioCategoryService _studioCategoryService;


        private readonly IConfiguration _configuration;
        private readonly IFileHandleService _fileHandleService;
        public StudioController(IStudioService studioService, IStudioCategoryService studioCategoryService, IConfiguration configuration, IFileHandleService fileHandleService, ICategoryService categoryService)
        {
            _studioService = studioService;
            _configuration = configuration;
            _fileHandleService = fileHandleService;
            _categoryService = categoryService;
            _studioCategoryService = studioCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var studios = await _studioService.GetAllStudiosAsync();
            return View(studios);
        }

        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            var model = new StudioForCreation();
            model.Categories = categories;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudioForCreation model)
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();

            var studio = new Studio
            {
                Name = model.Name,
                Description = model.Description,
                Logo = null
            };
            await _studioService.CreateStudioAsync(studio);

            var studio2 = await _studioService.GetStudioAsync(studio.Id);

            if (model.CategoryIds != null)
            {
                await _studioCategoryService.CreateStudioCategoryAsync(studio2.Id, model.CategoryIds);
            }

            if (file != null)
            {
                var uploadDir = _configuration["Uploads:FotoStudio"];
                var fileName = studio2.Id + "_" + studio2.Name;
                fileName = await _fileHandleService.UploadAndRenameFileAsync(file, uploadDir, fileName);
                studio2.Logo = fileName;
                await _studioService.UpdateStudioAsync(studio2);
            }

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
            model.Categories = await _categoryService.GetAllCategoriesAsync();
            model.StudioCategories = await _studioCategoryService.GetByStudioId(studio.Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudioForModification model)
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();

            var studio = await _studioService.GetStudioAsync(model.Id);

            studio.Name = model.Name;
            studio.Description = model.Description;

            await _studioCategoryService.CreateStudioCategoryAsync(studio.Id, model.CategoryIds);

            await _studioService.UpdateStudioAsync(studio);

            if (file != null)
            {
                var uploadDir = _configuration["Uploads:FotoStudio"];
                var fileName = studio.Id + "_" + studio.Name;
                fileName = await _fileHandleService.UploadAndRenameFileAsync(file, uploadDir, fileName);
                studio.Logo = fileName;
                await _studioService.UpdateStudioAsync(studio);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var studio = await _studioService.GetStudioAsync(id);
            if (studio.Logo != null)
            {
                var dir = _configuration["Uploads:FotoStudio"];
                _fileHandleService.RemoveImageFile(dir, studio.Logo);
            }
            await _studioService.DeleteStudioAsync(studio.Id);
            return RedirectToAction("Index");
        }
    }
}
