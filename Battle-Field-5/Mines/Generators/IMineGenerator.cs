//-----------------------------------------------------------------------
// <copyright file="IMineGenerator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Mines.Generators
{
    /// <summary>
    /// An Interface for representing a generator for creating new Mines.
    /// </summary>
    public interface IMineGenerator
    {
        /// <summary>
        /// Generates a Mine object.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        /// <returns>A new Mine Object.</returns>
        Mine Generate(Position position);
    }
}