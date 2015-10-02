namespace MineFieldApp.Cells
{
    using System;

    public class Cell
    {
        private CellStatus status;

        public Cell(Position position)
        {
            this.Status = CellStatus.Normal;
            this.Position = position;
        }

        public event EventHandler WhenDamaged;

        protected virtual void OnDamage(EventArgs args)
        {
            if (this.WhenDamaged != null)
            {
                WhenDamaged(this, args);
            }
        }

        public CellStatus Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        public Position Position { get; private set; }

        public virtual void TakeDamage(ICellDamageHandler damageHandler)
        { 
        }
    }
}