//-----------------------------------------------------------------------
// <copyright file="RandomMineGenerator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines.Factories
{
    using RNGs;
    using System;

    /// <summary>
    /// A MineGenerator which generates a random type of Mine.
    /// </summary>
    public class RandomMineFactory : IMineFactory
    {
        public RandomMineFactory(IRandomGenerator random)
        {
            this.Random = random;
        }

        public RandomMineFactory()
            : this(RandomGenerator.Instance)
        {

        }

        private IRandomGenerator Random { get; set; }

        /// <summary>
        /// Generates a random Mine object.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        /// <returns>A new Mine Object.</returns>
        public Mine Create(Position position, GameField field)
        {
            int randomNumber = this.Random.GetRandomBetween(0, 5);

            switch (randomNumber)
            {
                case 0:
                    return new TinyMine(position);
                case 1:
                    return new SmallMine(position);
                case 2:
                    return new MediumMine(position);
                case 3:
                    return new BigMine(position);
                case 4:
                    return new GiantMine(position);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}