﻿namespace BattleField_Console
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

    class ConsoleGame
    {
        public IEngine engine;

        public void InitGame(GameField field)
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            ICellDamageHandler damageHandler = new DefaultDamageHandler();
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
