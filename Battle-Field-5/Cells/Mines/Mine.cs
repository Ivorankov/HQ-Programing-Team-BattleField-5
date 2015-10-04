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
        private GameField field;

        protected Mine(Position position, GameField field)
            : base(position)
        {
            this.Field = field;
        }

        public GameField Field { get; private set;}

        public abstract List<Position> GetExplodingPattern();

        public override void TakeDamage(ICellDamageHandler damageHandler)
        {
            --this.Field.MinesCount;
            damageHandler.Damage(this);
        }
    }
}
