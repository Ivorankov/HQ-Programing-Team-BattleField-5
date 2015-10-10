namespace MineFieldApp.Cells
{
    public abstract class Cell
    {
        public Cell(Position position)
        {
            this.IsDestroyed = false;
            this.Position = position;
        }

        public bool IsDestroyed { get; set; } 

        public Position Position { get; private set; }

        public abstract void TakeDamage(ICellDamageHandler damageHandler);
    }
}