namespace Control
{
    public class Board
    {
        public Zone HomeP1 { get; set; }
        public Zone HomeP2 { get; set; }
        public Zone OutP1 { get; set; }
        public Zone OutP2 { get; set; }
        public Triangle[] TrianglesBar { get; set; }


        public Board()
        {
            HomeP1 = new Zone(ZoneType.Home, PlayerColor.White);
            HomeP2 = new Zone(ZoneType.Home, PlayerColor.Black);
            OutP1 = new Zone(ZoneType.Outer, PlayerColor.White);
            OutP2 = new Zone(ZoneType.Outer, PlayerColor.Black);
            TrianglesBar = new Triangle[2];
            TrianglesBar[0] = new Triangle(PlayerColor.White,0);
            TrianglesBar[1] = new Triangle(PlayerColor.Black,0);
        }
    }
}
