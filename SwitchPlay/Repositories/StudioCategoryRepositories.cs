using Microsoft.EntityFrameworkCore;
using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class StudioCategoryRepositories : BaseRepository<Category>
    {

        private readonly SwitchPlayContext _context;
        public StudioCategoryRepositories(SwitchPlayContext context) : base(context) { _context = context; }
    

        public async Task CreateStudioCategoryAsync(int studioId, List<int> categoryIds)
        {
            var sc = await _context.StudioCategories.ToListAsync();
            _context.RemoveRange(sc);

            if (categoryIds != null)
            {
                foreach (var id in categoryIds)
                {
                    _context.Add(new StudioCategory
                    {
                        StudioId = studioId,
                        CategoryId = id
                    });

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId)
        {
           return await _context.StudioCategories.Where(i => i.StudioId == studioId).Include(a => a.Category).ToListAsync();
        }
    }
}
