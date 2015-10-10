//-----------------------------------------------------------------------
// <copyright file="ICellDamageHandler.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains ICellDamageHandler interface
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells
{
    using Mines;

    /// <summary>
    /// An interface for the cell damage handler
    /// </summary>
    public interface ICellDamageHandler
    {
        /// <summary>
        /// Damages a cell.
        /// </summary>
        /// <param name="cell">The cell to be damaged.</param>
        void Damage(EmptyCell cell);

        /// <summary>
        /// Damages a mine.
        /// </summary>
        /// <param name="mine">The mine to be damaged.</param>
        void Damage(Mine mine);
    }
}