//-----------------------------------------------------------------------
// <copyright file="Mine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System;
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
            if (this.Status == CellStatus.Destoryed)
            {
                throw new MineDestroyedException("Mine can't explode it's alredy destroyed.");
            }

            foreach (var position in this.GetExplodingPattern())
            {
                if (field.IsInRange(position))
                {
                   field[position.Row, position.Col].TakeDamage();
                }
            }
        }

        protected abstract List<Position> GetExplodingPattern();
    }
}
