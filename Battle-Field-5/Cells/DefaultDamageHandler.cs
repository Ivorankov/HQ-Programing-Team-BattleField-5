//-----------------------------------------------------------------------
// <copyright file="DefaultDamageHandler.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains DefaultDamageHandler class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells
{
    using Mines;

    /// <summary>
    /// A class representing the default damage handler.
    /// </summary>
    public class DefaultDamageHandler : ICellDamageHandler
    {
        /// <summary>
        /// Damages a cell.
        /// </summary>
        /// <param name="cell">The cell to be damaged.</param>
        public void Damage(EmptyCell cell)
        {
            cell.IsDestroyed = true;
        }

        /// <summary>
        /// Damages a mine.
        /// </summary>
        /// <param name="mine">The mine to be damaged.</param>
        public void Damage(Mine mine)
        {
            mine.IsDestroyed = true;
        }
    }
}