//-----------------------------------------------------------------------
// <copyright file="RandomGenerator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains RandomGenerator class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.RNGs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A class representing random generator.
    /// </summary>
    public class RandomGenerator : IRandomGenerator
    {
        private static readonly Random Generator = new Random();

        private static Lazy<RandomGenerator> instance = new Lazy<RandomGenerator>(() => new RandomGenerator());
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator" /> class.
        /// </summary>
        protected RandomGenerator()
        {
        }

        /// <summary>
        /// Gets the RandomGenerator class instance.
        /// </summary>
        /// <value>Random generator instance.</value>
        public static RandomGenerator Instance
        {
            get
            {
                return RandomGenerator.instance.Value;
            }
        }

        /// <summary>
        /// Gets a random index.
        /// </summary>
        /// <param name="size">Maximum index value.</param>
        /// <returns>The randomly generated index.</returns>
        public int GetRandomIndex(int size)
        {
            return RandomGenerator.Generator.Next(size);
        }

        /// <summary>
        /// Gets a random value between two values.
        /// </summary>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <returns>The randomly generated value.</returns>
        public int GetRandomBetween(int minValue, int maxValue)
        {
            return RandomGenerator.Generator.Next(minValue, maxValue);
        }

        /// <summary>
        /// Gets a random set of positions.
        /// </summary>
        /// <param name="count">Number of positions.</param>
        /// <param name="first">Minimum position.</param>
        /// <param name="second">Maximum position.</param>
        /// <returns>A set of randomly generated positions.</returns>
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
