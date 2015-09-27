namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;

    //TODO Make the class non static and make Engine.GameField an instance of that class. Use Singleton pattern
    public static class Field
    {
        public static char[,] GenerateField(int size)
        {
            char[,] field = new char[size, size];
            int minesCount = DetermineMineCount(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = '-';
                }
            }

            for (int i = 0; i < minesCount; i++)
            {
                int mineX = Helper.Randomizer.Next(0, size);
                int mineY = Helper.Randomizer.Next(0, size);
                int mineType = Helper.Randomizer.Next('1', '6');

                //Mine newMine = new Mine( (MineType)mineType, new Position(mineX, mineY));
                field[mineX, mineY] = Convert.ToChar(mineType);
            }

            return field;
        }

        public static bool ContainsMines(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if ((field[i, j] != '-') && (field[i, j] != 'X'))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsPositionMine(int x, int y, char[,] field)
        {
            if (!Helper.CheckIfInRange(field, x, y))
            {
                return false;
            }
            else if ((field[x, y] == 'X') || (field[x, y] == '-'))
            {
                return false;
            }

            return true;
        }

        private static int DetermineMineCount(int size)
        {
            const double MinMineCount = 0.15;
            const double MaxMineCount = 0.3;

            double fields = (double)size * size;
            int lowBound = (int)(MinMineCount * fields);
            int upperBound = (int)(MaxMineCount * fields);

            return Helper.Randomizer.Next(lowBound, upperBound);
        }

        //TODO Add ExplodeMine(Mine mine) method
    }
}