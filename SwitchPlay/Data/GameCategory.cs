namespace SwitchPlay.Data
{
    public class GameCategory
    {
        public int CategoryId { get; set; }
        public int GameId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Game Game { get; set; }
    }
}
