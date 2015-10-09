namespace MineFieldApp.Cells
{
    using Mines;

    public class DefaultCellDamageHandler : ICellDamageHandler
    {
        public void Damage(EmptyCell cell)
        {
            cell.Status = CellStatus.Destroyed;
        }

        public void Damage(Mine mine)
        {
            mine.Status = CellStatus.Destroyed;
        }
    }
}