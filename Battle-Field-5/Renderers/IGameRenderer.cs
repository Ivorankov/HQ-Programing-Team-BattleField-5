using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    interface IGameRenderer
    {
        void ShowStartScreen();

        void ShowEndScreen(int score);

        void ShowGameScreen(int size, char[,] field);

        void RefreshGameField();

    }
}
