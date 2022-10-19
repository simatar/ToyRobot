using Business;
using Data;
using ToyConsole;

// UNITS will be the dimension of the table. e.g. UNITS = 5 will product a 5x5 dimension
int UNITS = 5;

// Container of the places generated from the grid dimension
List<Place> PLACES = Logic.GenerateGrid(UNITS);

// Initial placement of the robot will be by default in 1,1
Place initialPlace = Logic.GetPlace(PLACES, 1, 1);

// Set the initial direction where the robot will be facing
Robot ROBOT = new Robot(initialPlace, Direction.East);

string msg = "";
string robotDirection = "";
while (true)
{
    Console.Clear();
    Console.WriteLine("AI Media / Cloudstaff");
    Console.WriteLine("Coding Challenge");
    Console.WriteLine("Simulation of a Toy Robot moving on a square tabletop");

    robotDirection = Logic.GetCharImage(ROBOT.Direction);
    for (var row = 1; row < UNITS + 1; row++)
    {
        Table.GridLine(UNITS);
        for (var col = 1; col < UNITS + 1; col++)
        {
            Place place = PLACES.Where(m => m.X == row && m.Y == col).First();
            Console.Write("| " + place.X.ToString() + "," + place.Y.ToString() + " ");
            if (col == UNITS) Console.Write("|");
        }
        Console.WriteLine();
        for (var col = 1; col < UNITS + 1; col++)
        {
            Place place = PLACES.Where(m => m.X == row && m.Y == col).First();
            if (place == ROBOT.Place)
                Console.Write("|  " + robotDirection + "  ");
            else
                Console.Write("|     ");
            if (col == UNITS) Console.Write("|");
        }
        Console.WriteLine();
    }
    Table.GridLine(UNITS);

    Console.WriteLine();
    Console.WriteLine("Mr. Roboto is in {0},{1} heading ({2}){3}", ROBOT.Place.X, ROBOT.Place.Y, robotDirection, ROBOT.Direction.ToString());
    Console.WriteLine();
    Console.WriteLine(msg);
    Console.WriteLine();
    Console.WriteLine("Keys:");
    Console.WriteLine("  <- Left  = turn 90deg counter-clockwise");
    Console.WriteLine("  -> Right = turn 90deg clockwise");
    Console.WriteLine("  Spacebar = move Mr. Roboto");
    Console.WriteLine();
    Console.Write("Waiting for input.. ");
    ConsoleKeyInfo keyPress = Console.ReadKey(intercept: false);

    msg = "";
    switch (keyPress.Key)
    {
        case ConsoleKey.Escape:
            return;
        case ConsoleKey.LeftArrow:
            ROBOT.Direction = Logic.GetPreviousDirection(ROBOT.Direction);
            msg = "Action: Turn left 90deg";
            break;
        case ConsoleKey.RightArrow:
            ROBOT.Direction = Logic.GetNextDirection(ROBOT.Direction);
            msg = "Action: Turn right 90deg";
            break;
        case ConsoleKey.Spacebar:
            msg = "Action: Move";
            switch (ROBOT.Direction)
            {
                case Direction.North:
                    if (ROBOT.Place.X == 1)
                        msg = "Already on top";
                    else
                        ROBOT.Place = Logic.MoveUp(PLACES, ROBOT.Place);
                    break;
                case Direction.South:
                    if (ROBOT.Place.X == UNITS)
                        msg = "Already at the bottom";
                    else
                        ROBOT.Place = Logic.MoveDown(PLACES, ROBOT.Place);
                    break;
                case Direction.East:
                    if (ROBOT.Place.Y == UNITS)
                        msg = "Already at the end";
                    else
                        ROBOT.Place = Logic.MoveRight(PLACES, ROBOT.Place);
                    break;
                case Direction.West:
                    if (ROBOT.Place.Y == 1)
                        msg = "Already at the beginning";
                    else
                        ROBOT.Place = Logic.MoveLeft(PLACES, ROBOT.Place);
                    break;
            }
            break;
        default:
            // All other keys will be ignored, alert the user with a message
            msg = "*** YOU PRESSED AN INVALID KEY ***";
            break;
    }
}
