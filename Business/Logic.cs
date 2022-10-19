using Data;

namespace Business
{
    public static class Logic
    {
        /// <summary>
        /// Generates the Places in the grid the robot needs to be placed
        /// </summary>
        /// <param name="units">This is the number of dimensions of the square tabletop</param>
        /// <returns>List of places based on the given parameter of units (dimension)</returns>
        public static List<Place> GenerateGrid(int units)
        {
            List<Place> places = new List<Place>();
            Direction moves = Direction.None;
            for (var row = 1; row < units + 1; row++)
            {
                for (var col = 1; col < units + 1; col++)
                {
                    moves = Direction.None;
                    if (row > 1)
                        moves |= Direction.North;
                    if (row < units)
                        moves |= Direction.South;
                    if (col > 1)
                        moves |= Direction.West;
                    if (col < units)
                        moves |= Direction.East;

                    Place place = new Place(row, col, moves);

                    places.Add(place);
                }
            }
            return places;
        }

        /// <summary>
        /// Gets the previous enum from the list of Enum Direction
        /// </summary>
        /// <param name="direction">The current Enum Direction</param>
        /// <returns>The previous enum prior to the Enum Direction</returns>
        public static Direction GetPreviousEnum(Direction direction)
        {
            return (from Direction val in Enum.GetValues(typeof(Direction))
                    where val < direction
                    orderby val descending
                    select val).DefaultIfEmpty().First();
        }

        /// <summary>
        /// Gets the next enum from the list of Enum Direction
        /// </summary>
        /// <param name="direction">The current Enum Direction</param>
        /// <returns>The next enum after the Enum Direction</returns>
        public static Direction GetNextEnum(Direction direction)
        {
            return (from Direction val in Enum.GetValues(typeof(Direction))
                    where val > direction
                    orderby val
                    select val).DefaultIfEmpty().First();
        }

        /// <summary>
        /// Gets the character representation of the Enum Direction
        /// </summary>
        /// <param name="direction">The Enum Direction</param>
        /// <returns>The character representation of the Enum Direction</returns>
        public static string GetCharImage(Direction direction)
        {
            string charImage = "";
            switch (direction)
            {
                case Direction.North:
                    charImage = "^";
                    break;
                case Direction.East:
                    charImage = ">";
                    break;
                case Direction.South:
                    charImage = "v";
                    break;
                case Direction.West:
                    charImage = "<";
                    break;
            }
            return charImage;
        }

        /// <summary>
        /// Gets the previous Enum Direction
        /// </summary>
        /// <param name="currentDirection">The current Enum Direction</param>
        /// <returns>The previous Enum Direction</returns>
        public static Direction GetPreviousDirection(Direction currentDirection)
        {
            Direction newDirection = Logic.GetPreviousEnum(currentDirection);
            if (newDirection == Direction.None) newDirection = Direction.West;
            return newDirection;
        }

        /// <summary>
        /// Gets the next Enum Direction
        /// </summary>
        /// <param name="currentDirection">The current Enum Direction</param>
        /// <returns>The next Enum Direction</returns>
        public static Direction GetNextDirection(Direction currentDirection)
        {
            Direction newDirection = Logic.GetNextEnum(currentDirection);
            if (newDirection == Direction.None) newDirection = Direction.North;
            return newDirection;
        }

        /// <summary>
        /// Gets the instance of the Place from the list of places
        /// </summary>
        /// <param name="places">List of places to pick from</param>
        /// <param name="X">The row index from the table dimension</param>
        /// <param name="Y">The column index from the table dimension</param>
        /// <returns>The Place element corresponding to the X and Y coordinates</returns>
        public static Place GetPlace(List<Place> places, int X, int Y)
        {
            if (X == 0)
                throw new ArgumentOutOfRangeException(nameof(X), X, "X must have a value");
            if (Y == 0)
                throw new ArgumentOutOfRangeException(nameof(Y), Y, "Y must have a value");
            return places.Where(m => m.X == X && m.Y == Y).First();
        }

        /// <summary>
        /// Moves the current selected place to the previous row
        /// </summary>
        /// <param name="places">List of places</param>
        /// <param name="currentPlace">The current selected place</param>
        /// <returns>The new Place from the grid</returns>
        public static Place MoveUp(List<Place> places, Place currentPlace)
        {
            if (currentPlace.X == 1)
                throw new ArgumentException("Already on top");
            Place newPlace = GetPlace(places, currentPlace.X - 1, currentPlace.Y);
            return newPlace;
        }

        /// <summary>
        /// Moves the current selected place to the next row
        /// </summary>
        /// <param name="places">List of places</param>
        /// <param name="currentPlace">The current selected place</param>
        /// <returns>The new Place from the grid</returns>
        public static Place MoveDown(List<Place> places, Place currentPlace)
        {
            if (currentPlace.X == places.Max(m => m.X))
                throw new ArgumentException("Already at the bottom");
            Place newPlace = GetPlace(places, currentPlace.X + 1, currentPlace.Y);
            return newPlace;
        }

        /// <summary>
        /// Moves the current selected place to the right
        /// </summary>
        /// <param name="places">List of places</param>
        /// <param name="currentPlace">The current selected place</param>
        /// <returns>The new Place from the grid</returns>
        public static Place MoveRight(List<Place> places, Place currentPlace)
        {
            if (currentPlace.Y == places.Max(m => m.Y))
                throw new ArgumentException("Already at the end");
            Place newPlace = GetPlace(places, currentPlace.X, currentPlace.Y + 1);
            return newPlace;
        }

        /// <summary>
        /// Moves the current selected place to the left
        /// </summary>
        /// <param name="places">List of places</param>
        /// <param name="currentPlace">The current selected place</param>
        /// <returns>The new Place from the grid</returns>
        public static Place MoveLeft(List<Place> places, Place currentPlace)
        {
            if (currentPlace.Y == 1)
                throw new ArgumentException("Already at the beginning");
            Place newPlace = GetPlace(places, currentPlace.X, currentPlace.Y - 1);
            return newPlace;
        }
    }
}
