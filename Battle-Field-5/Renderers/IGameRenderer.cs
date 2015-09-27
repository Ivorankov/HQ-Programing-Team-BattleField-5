using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    interface IGameRenderer
    {
        int FieldSize { get; set; }

        void ShowStartScreen();

        void ShowEndScreen();

        void DrawGameField(int size, char[,] field);

        void Clear();

    }
}
