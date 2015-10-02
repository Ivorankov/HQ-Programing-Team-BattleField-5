﻿using MineFieldApp;
using MineFieldApp.Cells;
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
            ICellDamageHandler damageHandler = new ChainDamageHandler();
            Engine engine = new Engine(inputProvider, renderer, damageHandler);
            Console.WriteLine(12);
            engine.Start();
        }
    }
}
