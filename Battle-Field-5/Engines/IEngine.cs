//-----------------------------------------------------------------------
// <copyright file="IEngine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains IEngine interface
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Engines
{
    using Data;
    
    /// <summary>
    /// An interface for the game engine.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Initializes a game.
        /// </summary>
        /// <param name="field">The game field.</param>
        void Init(GameField field);

        /// <summary>
        /// Updates the game field.
        /// </summary>
        /// <param name="position">Position chosen by the player.</param>
        void UpdateField(Position position);

        /// <summary>
        /// Finishes a game.
        /// </summary>
        void GameOver();

        /// <summary>
        /// Creates a memento.
        /// </summary>
        /// <returns>The GameData to be saved.</returns>
        GameData CreateMemento();

        /// <summary>
        /// Loads a game from memento.
        /// </summary>
        /// <param name="memento">The game data to be loaded.</param>
        void SetMemento(GameData memento);
    }
}
