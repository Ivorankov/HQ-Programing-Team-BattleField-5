namespace MineFieldApp.RNGs
{
    using System;
    using System.Collections.Generic;

    public class RandomGenerator : IRandomGenerator
    {
        private static Lazy<RandomGenerator> instance = new Lazy<RandomGenerator>(() => new RandomGenerator());

        private static readonly Random Generator = new Random();

        protected RandomGenerator()
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

            while (positions.Count < count)
            {
                int x = this.GetRandomBetween(first.Row, second.Row + 1);
                int y = this.GetRandomBetween(first.Col, second.Col + 1);

                if (positions.Count > 0)
                {
                    foreach (Position position in positions)
                    {
                        if (position.Row == x && position.Col == y)
                        {
                            break;
                        }

                        positions.Add(new Position(x, y));
                        break;
                    }
                }
                else
                {
                    positions.Add(new Position(x, y));
                }
            }

            return positions;
        }
    }
}
