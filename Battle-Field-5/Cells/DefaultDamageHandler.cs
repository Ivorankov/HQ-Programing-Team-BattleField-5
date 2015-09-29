namespace MineFieldApp.Cells
{
    public class DefaultCellDamageHandler : ICellDamageHandler
    {
        public CellStatus Damage(Cell cell)
        {
            return CellStatus.Destoryed;
        }
    }
}