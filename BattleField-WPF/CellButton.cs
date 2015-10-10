//-----------------------------------------------------------------------
// <copyright file="CellButton.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System.Windows.Controls;
    using MineFieldApp;
    using MineFieldApp.Cells;

    /// <summary>
    /// Class that inherits Button and adds information about Cell position and status
    /// </summary>
    public class CellButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellButton" /> class
        /// </summary>
        /// <param name="row">Value that specifies the row in the grid element</param>
        /// <param name="col">Value that specifies the col in the grid element</param>
        /// <param name="status">Value that specifies the status of the cell </param>
        public CellButton(int row, int col, CellStatus status)
        {
            this.Position = new Position(row, col);
            this.Status = status;
        }

        /// <summary>
        /// Gets and sets position of the <see cref="CellButton"/> in the gird
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// Gets and sets the status of the <see cref="CellButton"/> in the gird
        /// </summary>
        public CellStatus Status { get; private set; }
    }
}
