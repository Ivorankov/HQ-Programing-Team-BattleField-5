//-----------------------------------------------------------------------
// <copyright file="Mine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a mine object
    /// </summary>
    public abstract class Mine
    {
        /// <summary>
        /// Initializes a new instance of the Mine class
        /// </summary>
        /// <param name="type">Type of the mine</param>
        /// <param name="position">The position of the mine</param>
        public Mine(Position position)
        {
            this.Position = position;
        }

        /// <summary>
        /// Gets or sets mine position
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// The method returns the exploding area of the mine
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area</returns>
        public abstract List<Position> Explode();
    }
}
