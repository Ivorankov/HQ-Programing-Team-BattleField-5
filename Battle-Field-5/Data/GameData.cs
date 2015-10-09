//-----------------------------------------------------------------------
// <copyright file="GameData.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains GameData class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Data
{
    using Cells;

    /// <summary>
    /// A class for storing main parameters for a game
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Initializes a new instance of the GameData class
        /// </summary>
        /// <param name="gameField">The game field</param>
        /// <param name="movesCount">Moves made by the player</param>
        /// <param name="damageHandler">The damage handler</param>
        public GameData(GameField gameField, int movesCount, ICellDamageHandler damageHandler)
        {
            this.GameField = gameField;
            this.MovesCount = movesCount;
            this.DamageHandler = damageHandler;
        }

        /// <summary>
        /// Gets or sets count of moves made by the player
        /// </summary>
        public int MovesCount { get; private set; }

        /// <summary>
        /// Gets or sets the game field
        /// </summary>
        public GameField GameField { get; private set; }

        /// <summary>
        /// Gets or sets the damage handler
        /// </summary>
        public ICellDamageHandler DamageHandler { get; private set; }
    }
}
