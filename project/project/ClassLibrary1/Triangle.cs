namespace Control
{
    public enum ZoneType
    {
        Outer,
        Home,
    }

    public enum PlayerColor
    {
        White,
        Black,
        None
    }

    public class Triangle
    {
        public int Count { get; set; }
        public PlayerColor Player { get; set; }

        public Triangle(PlayerColor player )
        {
            Count = 0;
            Player = player;
        }

        public Triangle(PlayerColor player, int chekersCount)
        {
            Count = chekersCount;
            Player = player;
        } 
    }
}
