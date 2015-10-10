namespace MineFieldApp.Cells
{
    public abstract class CellDecorator : Cell
    {
        protected CellDecorator(Cell cell)
            : base(cell.Position)
        {
            this.Cell = cell;
        }

        protected Cell Cell { get; private set; }

        public abstract override void TakeDamage(ICellDamageHandler damageHandler);
    }
}
