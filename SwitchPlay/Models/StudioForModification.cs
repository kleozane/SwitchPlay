using SwitchPlay.Data;

namespace SwitchPlay.Models
{
    public class StudioForModification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<StudioCategory> StudioCategories { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
