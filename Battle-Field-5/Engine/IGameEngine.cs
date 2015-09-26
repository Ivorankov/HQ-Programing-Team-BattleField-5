using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    public interface IGameEngine
    {
        Score score {get; }

        void StartGame();
    }
}
