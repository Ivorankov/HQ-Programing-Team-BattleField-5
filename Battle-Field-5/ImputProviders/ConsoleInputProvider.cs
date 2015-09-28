namespace BattleField
{
    using System;
    using System.Text.RegularExpressions;
    public class ConsoleInputProvider : IInputProvider
    {
        private const int MINIMUM_FIELD_SIZE = 1;
        private const int MAXIMUM_FIELD_SIZE = 10;
        public int GetFieldSize()
        {
            string input = null;
            int size = 0;
            do
            {
                Console.Write("Enter battle field size (between 1 and 10): ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1 || size > 10);

            return size;
        }

        public Position GetPosition()
        {
            string input = null;
            string digitRegex = @"(0|[1-9]\d*)";
            Regex regex = new Regex(String.Format(@"{0}\s+{0}", digitRegex));
            do
            {
                Console.Write("Enter mine coordinates: ");
                input = Console.ReadLine();
            }
            while (!regex.IsMatch(input.Trim()));

            string[] coordinates = input.Split(' ');

            return new Position(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }

        public string GetPlayerName()
        {
            string input = null;
            Console.Write("Concratularions you finished the game!!! Please enter your name: ");
            input = Console.ReadLine();

            return input;
        }
    }
}
