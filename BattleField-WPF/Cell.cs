using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleField_WPF
{
    class Cell : Button
    {
        public int Id { get; private set; }

        public Cell(int id)
        {
            this.Id = id;
        }
    }
}
