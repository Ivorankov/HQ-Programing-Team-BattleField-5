//-----------------------------------------------------------------------
// <copyright file="Mine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a Mine object.
    /// </summary>
    public abstract class Mine : Cell
    {
        protected Mine(Position position)
            : base(position)
        {
        }

        public abstract List<Position> GetExplodingPattern();

        public override void TakeDamage(ICellDamageHandler damageHandler)
        {
            damageHandler.Damage(this);
        }
    }
}
