using BattleField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleField_WPF
{
    enum status {normal, withMine, exploded};
    class Cell : Button
    {

        public Position Pos { get; private set; }
        public status Status { get; private set; }
        public Cell(int row, int col, status status)
        {
            this.Pos = new Position(row,col);
            this.Status = status;
        }
    }
}
