//-----------------------------------------------------------------------
// <copyright file="Mine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains Mine class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a Mine object.
    /// </summary>
    public abstract class Mine : CellDecorator
    {
        /// <summary>
        /// Initializes a new instance of the Mine class.
        /// </summary>
        /// <param name="cell">The cell which will be wrapped in mine.</param>
        protected Mine(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets the exploding area of the mine.
        /// </summary>
        /// <returns>Positions of the tiles of the exploding area.</returns>
        public abstract List<Position> GetExplodingPattern();

        /// <summary>
        /// Lets the DamageHander damage the mine.
        /// </summary>
        /// <param name="damageHandler">The concrete damage handler.</param>
        public override void TakeDamage(ICellDamageHandler damageHandler)
        {
            damageHandler.Damage(this);
        }
    }
}
