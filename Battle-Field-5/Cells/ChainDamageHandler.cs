namespace MineFieldApp.Cells
{
    using Mines;

    public class ChainDamageHandler : ICellDamageHandler
    {
        public void Damage(EmptyCell cell)
        {
            cell.Status = CellStatus.Destroyed;
        }

        public void Damage(Mine mine)
        {
            mine.Status = CellStatus.Destroyed;
            mine.Field.ReactToExplosion(mine.GetExplodingPattern(), this);
        }
    }
}