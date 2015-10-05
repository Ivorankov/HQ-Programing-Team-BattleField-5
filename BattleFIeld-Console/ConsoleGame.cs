using MineFieldApp;
using MineFieldApp.Cells;
using MineFieldApp.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField_Console
{
    class ConsoleGame
    {
        public Engine engine;

        public void InitGame(int fieldSize)
        {
            IRenderer renderer = new ConsoleRender();
            //ICellDamageHandler damageHandler = new DefaultCellDamageHandler();
            ICellDamageHandler damageHandler = new ChainDamageHandler();
            this.engine = new Engine(renderer, damageHandler);
            this.engine.Init(fieldSize);
        }
    }
}
