//-----------------------------------------------------------------------
// <copyright file="IInputProvider.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains IInputProvider interface
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp
{
    /// <summary>
    /// An interface for input providers.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Gets the field size from the player.
        /// </summary>
        /// <returns>Field size.</returns>
        int GetFieldSize();

        /// <summary>
        /// Gets player name.
        /// </summary>
        /// <returns>Name of the player.</returns>
        string GetPlayerName();
    }
}