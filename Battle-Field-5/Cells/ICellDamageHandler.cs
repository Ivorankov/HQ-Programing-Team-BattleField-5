namespace MineFieldApp.Cells
{
    using MineFieldApp.Cells.Mines;

    public interface ICellDamageHandler
    {
        void Damage(EmptyCell cell);

        void Damage(Mine mine);
    }
}