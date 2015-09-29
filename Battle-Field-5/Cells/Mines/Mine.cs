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
        protected Mine(ICellDamageHandler damageHandler, Position position)
            : base(damageHandler, position)
        {

        }

        protected Mine(Position position)
            : base(position)
        {

        }

        public void Explode(GameField field)
        {
            foreach (var positon in this.GetExplodingPattern())
            {
                field[positon.Y, positon.X].TakeDamage();
            }
        }

        protected abstract List<Position> GetExplodingPattern();
    }
}
