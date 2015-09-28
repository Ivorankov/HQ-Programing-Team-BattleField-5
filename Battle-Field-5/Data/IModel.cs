using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    interface IModel
    {
        char[,] Field { get; set; }
        int FieldSize { get; set; }
        string UserName { get; set; }
        int ExplodedMinesCount { get; set; }

    }
}
