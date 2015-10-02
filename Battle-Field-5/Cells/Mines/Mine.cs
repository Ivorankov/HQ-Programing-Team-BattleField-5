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
        protected Mine(Position position)
            : base(position)
        {

        }

        public void Explode(GameField field, ICellDamageHandler damageHandler)
        {
            if (this.Status == CellStatus.Destoryed)
            {
                throw new MineDestroyedException("Mine can't explode it's alredy destroyed.");
            }

            foreach (var position in this.GetExplodingPattern())
            {
                if (field.IsInRange(position))
                {
                    field[position.Row, position.Col].TakeDamage(damageHandler);
                }
            }
        }

        protected abstract List<Position> GetExplodingPattern();
    }
}
