using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField.Renderers
{
    interface IGameRenderer
    {
        void ShowStartScreen();

        void ShowEndScreen();

        void DrawGameField();

        void Clear();

    }
}
