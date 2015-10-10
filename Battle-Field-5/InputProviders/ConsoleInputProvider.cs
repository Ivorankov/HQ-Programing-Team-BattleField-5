namespace MineFieldApp
{
    using System;
    using System.Text.RegularExpressions;
    using MineFieldApp;

    public class ConsoleInputProvider : IInputProvider
    {
        public int GetFieldSize()
        {
            int result = 0;
            return this.GetValidUserInput(input => (int.TryParse(input, out result) && 1 <= result && result <= 10), "Enter battle field size (between 1 and 10): ", int.Parse);
        }

        public string GetPlayerName()
        {
            return this.GetValidUserInput(new Regex(@"^\w+$"), "Please enter your name: ", input => input);
        }

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