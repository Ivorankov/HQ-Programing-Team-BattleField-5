using MineFieldApp;
using MineFieldApp.Renderer;
using System;

namespace BattleField_Console
{
    class Program
    {
        public static void Main()
        {
            IInputProvider inputProvider = new ConsoleInputProvider();
            IRenderer renderer = new ConsoleRender();
            Engine engine = new Engine(inputProvider, renderer);
            engine.Start();
        }
    }
}
