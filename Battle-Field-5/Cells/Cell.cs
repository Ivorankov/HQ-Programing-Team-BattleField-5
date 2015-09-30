namespace MineFieldApp.Cells
{
    using System;

    public class Cell
    {
        private CellStatus status;

        public Cell(ICellDamageHandler damageHandler, Position position)
        {
            this.DamageHandler = damageHandler;

            this.Status = CellStatus.Normal;
            this.Position = position;
        }

        public Cell(Position position)
            : this(new DefaultCellDamageHandler(), position)
        {

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

            private set
            {
                this.status = value;
            }
        }

        public Position Position { get; private set; }

        private  ICellDamageHandler DamageHandler { get; set; }

        public void TakeDamage()
        {
            this.Status = this.DamageHandler.Damage(this);
            this.OnDamage(EventArgs.Empty);
        }
    }
}