namespace MineFieldApp.Cells
{
    using Mines;

    public class DefaultDamageHandler : ICellDamageHandler
    {
        public void Damage(EmptyCell cell)
        {
            cell.IsDestroyed = true;
        }

        public void Damage(Mine mine)
        {
            mine.IsDestroyed = true;
        }
    }
}