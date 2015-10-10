//-----------------------------------------------------------------------
// <copyright file="CellDecorator.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains CellDecorator class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells
{
    /// <summary>
    /// Class representing a cell decorator.
    /// </summary>
    public abstract class CellDecorator : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellDecorator" /> class.
        /// </summary>
        /// <param name="cell">The cell which is decorated.</param>
        protected CellDecorator(Cell cell) : base(cell.Position)
        {
            this.Cell = cell;
        }

        /// <summary>
        /// Gets the decorated cell object.
        /// </summary>
        /// <value>The cell object.</value>
        protected Cell Cell { get; private set; }

        /// <summary>
        /// Lets the DamageHander damage the cell.
        /// </summary>
        /// <param name="damageHandler">The concrete damage handler.</param>
        public abstract override void TakeDamage(ICellDamageHandler damageHandler);
    }
}
