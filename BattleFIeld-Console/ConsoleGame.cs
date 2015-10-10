namespace BattleField_Console
{
    using MineFieldApp;
    using MineFieldApp.Engines;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

    public class ConsoleGame
    {
        private IEngine engine;
        private IInputProvider inputProvider;
        private IRenderer renderer;
        private ICellDamageHandler damageHandler;

        public ConsoleGame(IInputProvider inputProvider, IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.engine = new ProxyEngine(renderer, damageHandler);
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        public void Start()
        {
            this.renderer.ShowWelcome();
            int fieldSize = this.inputProvider.GetFieldSize();
            GameField field = new GameField(fieldSize);
            this.engine.Init(field);
            this.PersistResult();
            this.renderer.ShowHighscores();
        }

        private void PersistResult()
        {
            string playerName = this.inputProvider.GetPlayerName();
            HighscoreLogger.Instance.AddHighscore(playerName, this.engine.MovesCount);
        }
    }
}
