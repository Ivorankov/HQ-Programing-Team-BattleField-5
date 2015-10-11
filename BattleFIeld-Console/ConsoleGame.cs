//-----------------------------------------------------------------------
// <copyright file="ConsoleGame.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains ConsoleGame class
// </summary>
//-----------------------------------------------------------------------
namespace BattleField_Console
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Engines;
    using MineFieldApp.Renderer;

    /// <summary>
    /// A class representing a console game.
    /// </summary>
    public class ConsoleGame
    {
        private IEngine engine;
        private IInputProvider inputProvider;
        private ConsoleRenderer renderer;
        private ICellDamageHandler damageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleGame" /> class.
        /// </summary>
        /// <param name="inputProvider">The input provider.</param>
        /// <param name="renderer">The renderer.</param>
        /// <param name="damageHandler">The damage handler.</param>
        public ConsoleGame(IInputProvider inputProvider, ConsoleRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.engine = new Engine(renderer, damageHandler);
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        public void Start()
        {
            this.renderer.ShowWelcome();

            this.renderer.ShowFieldSizePrompt();
            int fieldSize = this.inputProvider.GetFieldSize();
            GameField field = new GameField(fieldSize);

            this.engine.Init(field);

            this.renderer.ShowNamePrompt();

            string playerName = this.inputProvider.GetPlayerName();
            HighscoreLogger.Instance.AddHighscore(playerName, this.engine.MovesCount);

            this.renderer.ShowHighscores();
        }
    }
}
