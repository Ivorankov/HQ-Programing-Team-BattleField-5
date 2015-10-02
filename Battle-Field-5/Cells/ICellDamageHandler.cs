namespace MineFieldApp.Cells
{
    using MineFieldApp.Cells.Mines;

    public interface ICellDamageHandler
    {
        void Damage(Cell cell);

        void Damage(Mine mine);
    }
}