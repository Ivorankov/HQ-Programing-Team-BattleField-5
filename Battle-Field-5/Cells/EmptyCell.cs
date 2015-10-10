//-----------------------------------------------------------------------
// <copyright file="EmptyCell.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains EmptyCell class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells
{
    /// <summary>
    /// A class representing an empty cell.
    /// </summary>
    public class EmptyCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyCell" /> class.
        /// </summary>
        /// <param name="position">The position of the cell.</param>
        public EmptyCell(Position position) 
            : base(position)
        {
        }

        /// <summary>
        /// Lets the DamageHander damage the cell.
        /// </summary>
        /// <param name="damageHandler">The concrete damage handler.</param>
        public override void TakeDamage(ICellDamageHandler damageHandler)
        {
            damageHandler.Damage(this);
        }
    }
}