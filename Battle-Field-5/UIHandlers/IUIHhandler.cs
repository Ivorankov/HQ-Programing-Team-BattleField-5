using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    interface IUIHhandler
    {
        string TakeUserInput();

        string TakeUserName();

        string TakeGameFiledSize();

        string TakePositionCoordiantes();
    }
}
