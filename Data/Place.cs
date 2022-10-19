namespace Data
{
    public class Place
    {
        public Place(int x, int y, Direction moves)
        {
            X = x;
            Y = y;
            Moves = moves;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Direction Moves { get; set; }
    }
}
