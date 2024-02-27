using SwitchPlay.Data;
using System.ComponentModel.DataAnnotations;

namespace SwitchPlay.Models
{
    public class GameForModification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Requirements { get; set; }
        public double Size { get; set; }
        public string ReleaseDate { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<GameCategory> GameCategories { get; set; }
        public List<int> CategoryIds { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<GamePlatform> GamePlatforms { get; set; }
        public List<int> PlatformIds { get; set; }


        public IEnumerable<Studio> Studios { get; set; }
        public int StudioId { get; set; }
        public int? SelectedStudioId { get; set; }
    }
}
