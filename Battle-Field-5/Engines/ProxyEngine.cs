//-----------------------------------------------------------------------
// <copyright file="ProxyEngine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains ProxyEngine class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Engines
{
    using Data;
    using MineFieldApp.Cells;
    using MineFieldApp.Renderer;

    /// <summary>
    /// A class representing a proxy of the game engine.
    /// </summary>
    public class ProxyEngine : IEngine
    {
        private IEngine engine;

        private IRenderer renderer;

        private ICellDamageHandler damageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyEngine" /> class.
        /// </summary>
        /// <param name="renderer">Game renderer.</param>
        /// <param name="damageHandler">Cell damage handler.</param>
        public ProxyEngine(IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        /// <summary>
        /// Gets count of moves made by the player.
        /// </summary>
        /// <value>Moves count.</value>
        public int MovesCount
        {
            get
            {
                return this.engine.MovesCount;
            }
        }

        /// <summary>
        /// Initializes a game.
        /// </summary>
        /// <param name="field">The game field.</param>
        public void Init(GameField field)
        {
            // proxy will add restriction for init - once initialised cannot be overriden
            this.engine = new Engine(this.renderer, this.damageHandler);
            this.engine.Init(field);
        }

        /// <summary>
        /// Updates the game field.
        /// </summary>
        /// <param name="position">Position chosen by the player.</param>
        public void UpdateField(Position position)
        {
            this.engine.UpdateField(position);
        }

        /// <summary>
        /// Finishes a game.
        /// </summary>
        public void GameOver()
        {
        }

        /// <summary>
        /// Creates a memento.
        /// </summary>
        /// <returns>The GameData to be saved.</returns>
        public GameData CreateMemento()
        {
            return this.engine.CreateMemento();
        }

        /// <summary>
        /// Loads a game from memento.
        /// </summary>
        /// <param name="memento">The game data to be loaded.</param>
        public void SetMemento(GameData memento)
        {
            this.engine.SetMemento(memento);
        }
    }
}
