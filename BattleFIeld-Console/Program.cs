namespace BattleField_Console
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;
    using System;

    internal class Program
    {
        public static void Main()
        {
            GameField field = new GameField(10);
            IInputProvider inputProvider = new ConsoleInputProvider();
            IRenderer renderer = new ConsoleRenderer();
            ICellDamageHandler damageHandler = new DefaultDamageHandler();
            ConsoleGame consoleGame = new ConsoleGame(inputProvider, renderer, damageHandler);

            consoleGame.Start();
        }
    }
}
