using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class Model : IModel
    {
        public char[,] Field{ get; set; }

        public int FieldSize{ get; set; }

        public string UserName{ get; set; }

        public int ExplodedMinesCount{ get; set; }

    }
}
