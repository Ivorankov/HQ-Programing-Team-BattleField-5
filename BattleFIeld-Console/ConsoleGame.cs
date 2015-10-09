namespace BattleField_Console
{
    using MineFieldApp;
    using MineFieldApp.Engines;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

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
        }
    }
}
