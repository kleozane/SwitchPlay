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
    }
}
