using SwitchPlay.Data;

namespace SwitchPlay.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
