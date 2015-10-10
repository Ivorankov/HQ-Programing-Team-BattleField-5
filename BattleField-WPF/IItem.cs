using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BattleField_WPF
{
    interface IItem
    {
        ImageBrush GetBrush(int index);
    }
}
