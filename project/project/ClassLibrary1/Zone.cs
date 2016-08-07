namespace Control
{
    public class Zone
    {
        public ZoneType ZoneName { get; set; }
        public PlayerColor PlayerCol { get; set; }
        public readonly Triangle[] TrianglesZone;


        public Zone(ZoneType type, PlayerColor color)
        {
            ZoneName = type;
            PlayerCol = color;
            TrianglesZone = new Triangle[6];
            for (int i = 0; i < TrianglesZone.Length; i++)
            {
                TrianglesZone[i] = new Triangle(PlayerColor.None);
            }         
        }
    }
}
