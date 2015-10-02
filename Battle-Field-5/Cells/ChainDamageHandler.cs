namespace MineFieldApp.Cells
{
    using MineFieldApp.Cells.Mines;

    public class ChainDamageHandler : ICellDamageHandler
    {
        public void Damage(EmptyCell cell)
        {
            cell.Status = CellStatus.Destoryed;
        }

        public void Damage(Mine mine)
        {
            mine.Status = CellStatus.Destoryed;
            mine.Field.ReactToExplosion(mine.GetExplodingPattern(), this);
        }
    }
}