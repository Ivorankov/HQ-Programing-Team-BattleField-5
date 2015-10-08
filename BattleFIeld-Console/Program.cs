using MineFieldApp;
using MineFieldApp.Cells;
using MineFieldApp.Renderer;
using System;

namespace BattleField_Console
{
   internal class Program
    {
        public static void Main()
        {

            var consoleGame = new ConsoleGame();
            // Min 4 max 10
            var field = new GameField(10);
            consoleGame.InitGame(field);


        }
    }
}
