namespace MineFieldApp.Cells
{
    using MineFieldApp.Cells.Mines;

    public class DefaultCellDamageHandler : ICellDamageHandler
    {
        public virtual void Damage(Cell cell)
        {
            cell.Status = CellStatus.Destoryed;
        }

        public virtual void Damage(Mine mine)
        {
            mine.Status = CellStatus.Destoryed;
        }
    }
}