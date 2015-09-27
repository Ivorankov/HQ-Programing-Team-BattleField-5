//-----------------------------------------------------------------------
// <copyright file="RandomMineGenerator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Mines.Generators
{
    using System;

    /// <summary>
    /// A MineGenerator which generates a random type of Mine.
    /// </summary>
    public class RandomMineGenerator : IMineGenerator
    {
        /// <summary>
        /// Generates a random Mine object.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        /// <returns>A new Mine Object.</returns>
        public Mine Generate(Position position)
        {
            int randomNumber = Helper.Randomizer.Next(5);

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