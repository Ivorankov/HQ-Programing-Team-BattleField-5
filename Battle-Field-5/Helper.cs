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

    }
}