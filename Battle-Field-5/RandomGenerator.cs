namespace BattleField
{
    using System;
    using System.Collections.Generic;

    public static class RandomGenerator
    {
        private static Random generator = new Random();

        public static int GetRandomIndex(int size)
        {
            return generator.Next(size);
        }

        public static int GetRandomBetween(int minValue, int maxValue)
        {
            return generator.Next(minValue, maxValue);
        }

        public static IEnumerable<Position> GetUniquePointsBetween(int count, int rowsCount, int columnsCount)
        {
            ISet<Position> positions = new HashSet<Position>();
            while (positions.Count != count)
            {
                int x = GetRandomIndex(rowsCount);
                int y = GetRandomIndex(columnsCount);
                Position position = new Position(x, y);
                if (!positions.Contains(position))
                {
                    positions.Add(position);
                }
            }

            return positions;
        }
    }
}
