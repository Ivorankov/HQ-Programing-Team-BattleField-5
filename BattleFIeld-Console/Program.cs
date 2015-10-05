using MineFieldApp;
using MineFieldApp.Cells;
using MineFieldApp.Renderer;
using System;

namespace BattleField_Console
{
    class Program
    {
        private Engine engine;

        public static void Main()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            Console.WriteLine("Please enter field size"); // Todo Valdation
            var fieldSize = int.Parse(Console.ReadLine());
            var consoleGame = new ConsoleGame();
            consoleGame.InitGame(fieldSize);

            while(true)
            {
                Console.WriteLine("Enter position");// Todo validation
                var input = Console.ReadLine().Split(' ');
                var pos = new Position(int.Parse(input[0]), int.Parse(input[1]));
                consoleGame.engine.UpdateField(pos);
            }
        }
    }
}
