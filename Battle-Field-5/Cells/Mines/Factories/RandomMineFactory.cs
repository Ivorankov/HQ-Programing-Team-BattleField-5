//-----------------------------------------------------------------------
// <copyright file="RandomMineFactory.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains RandomMineFactory class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines.Factories
{
    using System;
    using RNGs;

    /// <summary>
    /// A mine factory which generates a random type of Mine.
    /// </summary>
    public class RandomMineFactory : IMineFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomMineFactory" /> class.
        /// </summary>
        /// <param name="random">Random generator.</param>
        public RandomMineFactory(IRandomGenerator random)
        {
            this.Random = random;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomMineFactory" /> class.
        /// </summary>
        public RandomMineFactory()
            : this(RandomGenerator.Instance)
        {
        }

        private IRandomGenerator Random { get; set; }

        /// <summary>
        /// Generates a random Mine object.
        /// </summary>
        /// <param name="cell">The cell which will be wrapped in mine.</param>
        /// <returns>A new Mine Object.</returns>
        public Mine Create(Cell cell)
        {
            int randomNumber = this.Random.GetRandomBetween(0, 5);

            switch (randomNumber)
            {
                case 0:
                    return new TinyMine(cell);
                case 1:
                    return new SmallMine(cell);
                case 2:
                    return new MediumMine(cell);
                case 3:
                    return new BigMine(cell);
                case 4:
                    return new GiantMine(cell);
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}