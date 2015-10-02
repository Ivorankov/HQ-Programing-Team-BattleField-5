namespace MineFieldApp.Cells
{
    using System;

    public class EmptyCell : Cell
    {
        public EmptyCell(Position position) 
            : base(position)
        {
        }

        public override void TakeDamage(ICellDamageHandler damageHandler)
        {
            damageHandler.Damage(this);
            OnDamage(EventArgs.Empty);
        }
    }
}