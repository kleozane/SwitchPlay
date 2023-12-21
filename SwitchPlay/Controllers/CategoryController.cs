using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Services;
using SwitchPlay.Models;

namespace SwitchPlay.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Add()
        {
            var model = new CategoryForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryForCreation model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            await _categoryService.CreateCategoryAsync(category);
            return RedirectToAction("Index");
        }
    }
}
