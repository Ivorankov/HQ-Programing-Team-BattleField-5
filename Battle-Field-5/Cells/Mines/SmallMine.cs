//-----------------------------------------------------------------------
// <copyright file="SmallMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a SmallMine object.
    /// </summary>
    public class SmallMine : Mine
    {
        /// <summary>
        /// Initializes a new instance of the SmallMine class.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        public SmallMine(Position position)
            : base(position)
        {
        }

        /// <summary>
        /// The method returns the exploding area of the mine.
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area.</returns>
        public override List<Position> GetExplodingPattern()
        {
            return MineAssistant.GetNormalExplosion(this.Position, 1);
        }
    }
}
