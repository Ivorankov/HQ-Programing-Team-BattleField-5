//-----------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains IRenderer interface
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Renderer
{
    using System;
    using MineFieldApp.Data;

    /// <summary>
    /// An interface for renderers.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// An event for getting a position.
        /// </summary>
        event EventHandler<PositionEventArgs> InputPosition;

        /// <summary>
        /// Shows welcome screen.
        /// </summary>
        void ShowWelcome();

        /// <summary>
        /// Show game field.
        /// </summary>
        /// <param name="field">The game field.</param>
        void ShowGameField(GameField field);

        /// <summary>
        /// Refreshes game field.
        /// </summary>
        /// <param name="field">The game field.</param>
        void RefreshGameField(GameField field);

        /// <summary>
        /// Shows an error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void ShowErrorMessage(string message);

        /// <summary>
        /// Shows high scores.
        /// </summary>
        void ShowHighscores();

        /// <summary>
        /// Shows game over screen.
        /// </summary>
        /// <param name="data">Current game data.</param>
        void ShowGameOver(GameData data);
    }
}
