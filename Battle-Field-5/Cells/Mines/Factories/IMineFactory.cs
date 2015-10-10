//-----------------------------------------------------------------------
// <copyright file="IMineGenerator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines.Factories
{
    /// <summary>
    /// An Interface for representing a generator for creating new Mines.
    /// </summary>
    public interface IMineFactory
    {
        /// <summary>
        /// Generates a Mine object.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        /// <returns>A new Mine Object.</returns>
        Mine Create(Cell cell);
    }
}