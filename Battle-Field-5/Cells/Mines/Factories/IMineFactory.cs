//-----------------------------------------------------------------------
// <copyright file="IMineFactory.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains IMineFactory interface
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines.Factories
{
    /// <summary>
    /// An Interface for representing a factory for creating new Mines.
    /// </summary>
    public interface IMineFactory
    {
        /// <summary>
        /// Generates a mine object.
        /// </summary>
        /// <param name="cell">The cell which will be wrapped in mine object.</param>
        /// <returns>Mine object.</returns>
        Mine Create(Cell cell);
    }
}