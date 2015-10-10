//-----------------------------------------------------------------------
// <copyright file="IRandomGenerator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains IRandomGenerator interface
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.RNGs
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface for game random generator.
    /// </summary>
    public interface IRandomGenerator
    {
        /// <summary>
        /// Gets a random index.
        /// </summary>
        /// <param name="size">Maximum index value.</param>
        /// <returns>The randomly generated index.</returns>
        int GetRandomIndex(int size);

        /// <summary>
        /// Gets a random value between two values.
        /// </summary>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <returns>The randomly generated value.</returns>
        int GetRandomBetween(int minValue, int maxValue);

        /// <summary>
        /// Gets a random set of positions.
        /// </summary>
        /// <param name="count">Number of positions.</param>
        /// <param name="first">Minimum position.</param>
        /// <param name="second">Maximum position.</param>
        /// <returns>A set of randomly generated positions.</returns>
        HashSet<Position> GetUniquePointsBetween(int count, Position first, Position second);
    }
}