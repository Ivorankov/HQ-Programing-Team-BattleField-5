//-----------------------------------------------------------------------
// <copyright file="CellStatus.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains CellStatus enumeration
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells
{
    /// <summary>
    /// An enumeration for the cell status.
    /// </summary>
    public enum CellStatus
    {
        /// <summary>
        /// A normal empty cell.
        /// </summary>
        Normal,

        /// <summary>
        /// A cell with mine.
        /// </summary>
        WithMine,

        /// <summary>
        /// Destroyed cell.
        /// </summary>
        Destroyed
    }
}