namespace Data
{
    public class Robot
    {
        public Robot(Place place, Direction direction)
        {
            Place = place;
            Direction = direction;
        }

        public Place Place { get; set; } = null!;

        public Direction Direction { get; set; }
    }
}
