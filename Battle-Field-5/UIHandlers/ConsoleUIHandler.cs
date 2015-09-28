using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class ConsoleUIHandler : IUIHhandler
    {
        private const int USER_NAME_MIN_LENGTH = 0;
        private const int USER_NAME_MAX_LENGTH = 6;

        public ConsoleUIHandler()
        {

        }

        public string TakeUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
        //TODO: Create a validator object
        public string TakeUserName()
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

        public string TakeGameFiledSize()
        {
            string dimentions = string.Empty;

                dimentions = this.TakeUserInput();


            return dimentions;
        }

        public string TakePositionCoordiantes()
        {
            string coordinates = string.Empty;
            do
            {
                coordinates = this.TakeUserInput();
            } while (coordinates.Length != 3);

            return coordinates;
        }

    }
}
