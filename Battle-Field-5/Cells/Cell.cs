//-----------------------------------------------------------------------
// <copyright file="Cell.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains Cell class
// </summary>
//-----------------------------------------------------------------------
    namespace MineFieldApp.Cells
    {
    /// <summary>
    /// Class representing a cell object.
    /// </summary>
    public abstract class Cell
    {
        private bool isDestroyed;

        /// <summary>
        /// Initializes a new instance of the Cell class.
        /// </summary>
        /// <param name="position">The position of the cell.</param>
        public Cell(Position position)
        {
            this.IsDestroyed = false;
            this.Position = position;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the cell is destroyed.
        /// </summary>
        /// <value>True if the cell is destroyed, false otherwise.</value>
        public bool IsDestroyed { get; set; }

        /// <summary>
        /// Gets the Position of the cell.
        /// </summary>
        /// <value>The position of the cell.</value>
        public Position Position { get; private set; }

        /// <summary>
        /// Lets the DamageHander damage the cell.
        /// </summary>
        /// <param name="damageHandler">The concrete damage handler.</param>
        public abstract void TakeDamage(ICellDamageHandler damageHandler);
    }
}