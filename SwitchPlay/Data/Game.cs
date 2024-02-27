using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchPlay.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public string Requirements { get; set; }
        public double Size { get; set; }
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("StudioId")]
        public int? StudioId { get; set; }
        public virtual Studio Studio { get; set; }

        public ICollection<GameCategory> GameCategories { get; set; }
        public ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}
