using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField.UIHandlers
{
    public class ConsoleUIHandler
    {
        private const int USER_NAME_MIN_LENGTH = 0;
        private const int USER_NAME_MAX_LENGTH = 6;
        public ConsoleUIHandler()
        {

        }

        private string TakeUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
        //TODO: Create a validator object
        private string TakeUserName()
        {
            string userName = string.Empty;
            do
            {
                userName = this.TakeUserInput();
            } while (
                USER_NAME_MIN_LENGTH > userName.Length &&
                userName.Length > USER_NAME_MAX_LENGTH);

            return userName;
        }

        private string TakeGameFieldSize()
        {
            string dimentions = string.Empty;
            do
            {
                dimentions = this.TakeUserInput();
            } while (dimentions.Length != 3);

            return dimentions;
        }
    }
}
