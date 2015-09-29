namespace MineFieldApp.RNGs
{
    using System;
    using System.Collections.Generic;

    public class RandomGenerator : IRandomGenerator
    {
        private static Lazy<RandomGenerator> instance = new Lazy<RandomGenerator>(() => new RandomGenerator());

        private static readonly Random Generator = new Random();

        private RandomGenerator()
        {

        }

        public static RandomGenerator Instance 
        {
            get
            {
                return RandomGenerator.instance.Value;
            }
        }

        public int GetRandomIndex(int size)
        {
            return RandomGenerator.Generator.Next(size);
        }

        public int GetRandomBetween(int minValue, int maxValue)
        {
            return RandomGenerator.Generator.Next(minValue, maxValue);
        }

        public HashSet<Position> GetUniquePointsBetween(int count, Position first, Position second)
        {
            HashSet<Position> positions = new HashSet<Position>();

            for (int i = 0; i < count; i++)
            {
                int x = this.GetRandomBetween(first.X, second.X + 1);
                int y = this.GetRandomBetween(first.Y, second.Y + 1);

                positions.Add(new Position(x, y));
            }

            return positions;
        }
    }
}
