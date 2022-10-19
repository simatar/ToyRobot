namespace ToyConsole
{
    public static class Table
    {
        /// <summary>
        /// Generates the lines needed for displaying the table
        /// </summary>
        /// <param name="units">This is the number of dimensions of the square tabletop</param>
        public static void GridLine(int units)
        {
            for (var col = 1; col < units + 1; col++)
            {
                Console.Write("|-----");
                if (col == units) Console.Write("|");
            }
            Console.WriteLine();
        }
    }
}
