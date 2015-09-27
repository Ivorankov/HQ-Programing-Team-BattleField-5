namespace MineFieldApp
{
    using System;

    public static class Helper
    {
        public static readonly Random Randomizer = new Random();

        public static bool CheckIfInRange(char[,] field, int x, int y)
        {
            if (x < 0 || y < 0 || x >= field.GetLength(0) || y >= field.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static Position ParseInputToPosition(string input)
        {
            if (input == null || input.Length < 3 || !input.Contains(" "))
            {
                Console.WriteLine("Invalid index!");
                return new Position(-1, -1);
            }

            string[] splitString = input.Split(' ');

            int x;
            if (!int.TryParse(splitString[0], out x))
            {
                Console.WriteLine("Invalid index!");
                return new Position(-1, -1);
            }

            int y;
            if (!int.TryParse(splitString[1], out y))
            {
                Console.WriteLine("Invalid index!");
                return new Position(-1, -1);
            }

            return new Position(x,y);
        }
    }
}