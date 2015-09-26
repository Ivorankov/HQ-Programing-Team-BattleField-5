using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    interface IGameRenderer
    {
         int FieldWidth { get; }

         int FieldHeight { get; }

        void ShowStartScreen();

        void ShowEndScreen();

        void DrawGameField();

        void Clear();

    }
}
