namespace MineFieldApp.Cells
{
    using MineFieldApp.Cells.Mines;

    public class DefaultDamageHandler : ICellDamageHandler
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