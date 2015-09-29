namespace MineFieldApp.Cells
{
    public interface ICellDamageHandler
    {
        CellStatus Damage(Cell cell);
    }
}