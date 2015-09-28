using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
     interface IGameEngine
    {
        Score score {get; }

        IGameRenderer Renderer { get; set; }

        IUIHhandler UIHandler { get; set; }

        IModel Model { get; set; }

        void StartGame();
    }
}
