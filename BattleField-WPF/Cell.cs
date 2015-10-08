namespace BattleField_WPF
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using System.Windows.Controls;

    class CellButton : Button
    {

        public Position Pos { get; private set; }

        public CellStatus Status { get; private set; }

        public CellButton(int row, int col, CellStatus status)
        {
            this.Pos = new Position(row, col);
            this.Status = status;
        }

        public CellButton(int row, int col)
        {
            this.Pos = new Position(row, col);
        }

    }
}
