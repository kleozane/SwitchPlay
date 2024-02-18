namespace SwitchPlay.Data
{
    public class StudioCategory
    {
        public int CategoryId { get; set; }
        public int StudioId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Studio Studio { get; set; }
    }
}
