using Microsoft.EntityFrameworkCore;
using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class GameCategoryRepository : BaseRepository<Category>
    {

        private readonly SwitchPlayContext _context;
        public GameCategoryRepository(SwitchPlayContext context) : base(context) { _context = context; }


        public async Task CreateGameCategoryAsync(int studioId, List<int> categoryIds)
        {
            var sc = await _context.GameCategories.ToListAsync();
            _context.RemoveRange(sc);

            if (categoryIds != null)
            {
                foreach (var id in categoryIds)
                {
                    _context.Add(new GameCategory
                    {
                        GameId = studioId,
                        CategoryId = id
                    });

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<GameCategory>> GetByGameId(int studioId)
        {
            return await _context.GameCategories.Where(i => i.GameId == studioId).Include(a => a.Category).ToListAsync();
        }
    }
}
