//-----------------------------------------------------------------------
// <copyright file="ConsoleInputProvider.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains ConsoleInputProvider class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp
{
    using System;
    using System.Text.RegularExpressions;
    using MineFieldApp;

    /// <summary>
    /// A class representing an input provider for the console.
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Gets the field size from the player.
        /// </summary>
        /// <returns>Field size.</returns>
        public int GetFieldSize()
        {
            int result = 0;
            return this.GetValidUserInput(input => (int.TryParse(input, out result) && 1 <= result && result <= 10), "Enter battle field size (between 1 and 10): ", int.Parse);
        }

        /// <summary>
        /// Gets player name.
        /// </summary>
        /// <returns>Name of the player.</returns>
        public string GetPlayerName()
        {
            return this.GetValidUserInput(new Regex(@"\w+"), "Please enter your name: ", input => input);
        }

        /// <summary>
        /// Gets any user input.
        /// </summary>
        /// <returns>The input.</returns>
        protected virtual string GetUserInput()
        {
            return Console.ReadLine();
        }

        private T GetValidUserInput<T>(Regex regex, string prompt, Func<string, T> parser)
        {
            return this.GetValidUserInput<T>(input => regex.IsMatch(input), prompt, parser);
        }

        private T GetValidUserInput<T>(Predicate<string> validator, string prompt, Func<string, T> parser)
        {
            string input = null;
            do
            {
                Console.WriteLine(prompt);
                input = this.GetUserInput();
            }
            while (!validator.Invoke(input));

            return parser.Invoke(input);
        }
    }
}