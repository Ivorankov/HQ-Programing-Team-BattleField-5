namespace BattleField
{
    using BattleField.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RandomGenerator
    {
        private static Random generator = new Random();
        private static CellType[] mineTypes;
        private static CellType[] MineTypes
        {
            get
            {
                if (mineTypes == null)
                {
                    mineTypes = Enum.GetValues(typeof(CellType)).Cast<CellType>().Where(type => type.ToString().Contains("MINE")).ToArray();
                }

                return mineTypes;
            }
        }

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

        public static CellType GetRandomMineType()
        {
            int randomIndex = GetRandomIndex(MineTypes.Length);
            return MineTypes[randomIndex];
        }
    }
}
