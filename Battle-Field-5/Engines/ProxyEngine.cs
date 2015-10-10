namespace MineFieldApp.Engines
{
    using Data;
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

        public int MovesCount
        {
            get
            {
                return this.engine.MovesCount;
            }
        }

        public void Init(GameField field)
        {
            // proxy will add restriction for init - once initialised cannot be overriden
            this.engine = new Engine(this.renderer, this.damageHandler);
            this.engine.Init(field);
        }

        public void UpdateField(Position position)
        {
            this.engine.UpdateField(position);
        }

        public void GameOver()
        {
        }

        public GameData CreateMemento()
        {
            return this.engine.CreateMemento();
        }

        public void SetMemento(GameData memento)
        {
            this.engine.SetMemento(memento);
        }
    }
}
