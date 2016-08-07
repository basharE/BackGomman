namespace Control
{
    public class Player
    {
        public PlayerColor Color { get; set; }
        private int Points { get; set; }

        public Player(PlayerColor color)
        {
            Color = color;
            Points = 0;
        }
    }
}
