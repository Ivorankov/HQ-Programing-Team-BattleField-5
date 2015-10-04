namespace MineFieldApp
{
    using System;
    using System.Text.RegularExpressions;
    public class ConsoleInputProvider : IInputProvider
    {
        public int GetFieldSize()
        {
            return GetValidUserInput(input => (1 <= int.Parse(input) && int.Parse(input) <= 10), "Enter battle field size (between 1 and 10): ", int.Parse);
        }

        public Position GetPosition()
        {
            string numberRegex = @"(0|[1-9]\d*)";
            return GetValidUserInput(new Regex(String.Format(@"{0}\s+{0}", numberRegex)), "Enter mine coordinates: ", i =>
            {
                string[] input = i.Split(' ');
                return new Position(int.Parse(input[0]), int.Parse(input[1]));
            });
        }

        public string GetPlayerName()
        {
            return GetValidUserInput(new Regex(@"\w+"), "Please enter your name: ", input => input);
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
                input = Console.ReadLine();
            }
            while (!validator.Invoke(input));

            return parser.Invoke(input);
        }
    }
}
