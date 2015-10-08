namespace BattleField_Console
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

    class ConsoleGame
    {
        public IEngine engine;

        public void InitGame(GameField field)
        {
            IRenderer renderer = new ConsoleRender();
            //ICellDamageHandler damageHandler = new DefaultCellDamageHandler();
            ICellDamageHandler damageHandler = new ChainDamageHandler();
            this.engine = new ProxyEngine(renderer, damageHandler);
            this.engine.Init(field);
        }
    }
}
