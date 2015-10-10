namespace MineFieldApp.Cells
{
    public abstract class Cell
    {
        private CellStatus status;

        public Cell(Position position)
        {
            this.Status = CellStatus.Normal;
            this.Position = position;
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

        public abstract void TakeDamage(ICellDamageHandler damageHandler);
    }
}