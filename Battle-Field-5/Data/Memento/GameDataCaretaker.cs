//-----------------------------------------------------------------------
// <copyright file="GameDataCaretaker.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains GameDataCaretaker class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Data
{
    /// <summary>
    /// A class that stores GameData object in order to be restored later
    /// </summary>
    public class GameDataCaretaker
    {
        private GameData memento;

        /// <summary>
        /// Gets or sets the GameData object
        /// </summary>
        public GameData GameData
        {
            get { return this.memento; }
            set { this.memento = value; }
        }
    }
}
