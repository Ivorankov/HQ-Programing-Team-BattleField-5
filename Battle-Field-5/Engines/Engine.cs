//-----------------------------------------------------------------------
// <copyright file="Engine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains Engine class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Engines
{
    using Cells;
    using Cells.Mines;
    using Data;
    using Renderer;

    /// <summary>
    /// A class representing a game engine.
    /// </summary>
    public class Engine : IEngine
    {
        private IRenderer renderer;

        private GameField field;

        private int movesCount;

        private ICellDamageHandler damageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine" /> class.
        /// </summary>
        /// <param name="renderer">Game renderer.</param>
        /// <param name="damageHandler">Cell damage handler.</param>
        public Engine(IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        /// <summary>
        /// Initializes a game.
        /// </summary>
        /// <param name="field">The game field.</param>
        public void Init(GameField field)
        {
            this.field = field;
            this.movesCount = 0;
            this.renderer.InputPosition += (rendererObj, positionArg) =>
            {
                this.UpdateField(positionArg.Position);
            };

            this.renderer.ShowGameField(field);
        }

        /// <summary>
        /// Updates the game field.
        /// </summary>
        /// <param name="pos">Position chosen by the player.</param>
        public void UpdateField(Position pos)
        {
            Position position = pos;

            if (this.field.IsInRange(position) && (this.field[position.Row, position.Col] is Mine))
            {
                this.movesCount++;
                Mine mine = this.field[position.Row, position.Col] as Mine;
                this.field.ReactToExplosion(mine.GetExplodingPattern(), this.damageHandler);
            }
            else
            {
                this.renderer.ShowErrorMessage("Invalid coordinates or the selected cell is not a mine.");
            }

            if (this.field.HasMinesLeft())
            {
                this.renderer.RefreshGameField(this.field);
            }
            else
            {
                this.GameOver();
            }
        }

        /// <summary>
        /// Finishes a game.
        /// </summary>
        public void GameOver()
        {
            var gameData = new GameData(this.field, this.movesCount, this.damageHandler);
            this.renderer.ShowGameOver(gameData);
            this.renderer.ShowHighscores(gameData);
        }

        /// <summary>
        /// Creates a memento.
        /// </summary>
        /// <returns>The GameData to be saved.</returns>
        public GameData CreateMemento()
        {
            return new GameData(this.field, this.movesCount, this.damageHandler);
        }

        /// <summary>
        /// Loads a game from memento.
        /// </summary>
        /// <param name="memento">The game data to be loaded.</param>
        public void SetMemento(GameData memento)
        {
            this.field = memento.GameField;
            this.movesCount = memento.MovesCount;
            this.damageHandler = memento.DamageHandler;
        }
    }
}