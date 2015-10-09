namespace MineFieldApp.Cells
{
    using Mines;

    public interface ICellDamageHandler
    {
        void Damage(EmptyCell cell);

        void Damage(Mine mine);
    }
}