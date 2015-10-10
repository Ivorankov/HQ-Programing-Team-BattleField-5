namespace BattleField_WPF
{
    using System.Windows.Controls;
    using MineFieldApp;
    using MineFieldApp.Cells;

    public class CellButton : Button
    {
        public CellButton(int row, int col, CellStatus status)
        {
            this.Position = new Position(row, col);
            this.Status = status;
        }

        public CellButton(int row, int col)
        {
            this.Position = new Position(row, col);
        }

        public Position Position { get; private set; }

        public CellStatus Status { get; private set; }
    }
}
