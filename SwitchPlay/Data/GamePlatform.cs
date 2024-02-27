namespace SwitchPlay.Data
{
    public class GamePlatform
    {
        public int PlatformId { get; set; }
        public int GameId { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Game Game { get; set; }
    }
}
