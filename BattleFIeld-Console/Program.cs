namespace BattleField_Console
{
    using MineFieldApp;
    using System;

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
