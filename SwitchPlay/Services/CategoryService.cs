using SwitchPlay.Data;
using SwitchPlay.Repositories;

namespace SwitchPlay.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategeoryRepository _context;
        public CategoryService(CategeoryRepository context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _context.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _context.RemoveAsync(id);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.GetAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.GetAllAsync();
        }
    }
}
