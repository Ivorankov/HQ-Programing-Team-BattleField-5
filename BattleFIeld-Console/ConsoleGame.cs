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
        public IEngine engine;

        public void InitGame(GameField field)
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            //ICellDamageHandler damageHandler = new DefaultCellDamageHandler();
            ICellDamageHandler damageHandler = new ChainDamageHandler();
            this.engine = new ProxyEngine(renderer, damageHandler);
            this.engine.Init(field);

            while (true)
            {
                Position pos = renderer.SelectPosition();
                this.engine.UpdateField(pos);
            }
        }
    }
}
