namespace BattleField_WPF
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using System.Windows.Controls;

    class CellButton : Button
    {

        public Position Position { get; private set; }

        public CellStatus Status { get; private set; }

        public CellButton(int row, int col, CellStatus status)
        {
            this.Position = new Position(row, col);
            this.Status = status;
        }

        public CellButton(int row, int col)
        {
            this.Position = new Position(row, col);
        }

    }
}
