using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MineFieldApp;
using MineFieldApp.Cells;

namespace BattleField_WPF
{
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
