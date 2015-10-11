//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains Program class
// </summary>
//-----------------------------------------------------------------------
namespace BattleField_Console
{
    using System;
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

    /// <summary>
    /// A starting point for the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method of the program.
        /// </summary>
        public static void Main()
        {
            IInputProvider inputProvider = new ConsoleInputProvider();
            IRenderer renderer = new ConsoleRenderer();
            ICellDamageHandler damageHandler = new DefaultDamageHandler();
            ConsoleGame consoleGame = new ConsoleGame(inputProvider, renderer, damageHandler);

            consoleGame.Start();
        }
    }
}
