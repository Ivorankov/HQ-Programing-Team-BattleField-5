namespace MineFieldApp
{
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

    public class ProxyEngine : IEngine
    {
        private IEngine engine;

        private IRenderer renderer;

        private ICellDamageHandler damageHandler;


        public ProxyEngine(IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        public void Init(GameField field)
        {
            this.engine = new Engine(this.renderer, this.damageHandler);// proxy will add restriction for init - once initialised cannot be overriden
            this.engine.Init(field);
        }


        public void UpdateField(Position position)
        {
            this.engine.UpdateField(position);
        }

        public void GameOver()
        {

        }
    }
}
