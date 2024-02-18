using SwitchPlay.Data;

namespace SwitchPlay.Models
{
    public class StudioForCreation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
