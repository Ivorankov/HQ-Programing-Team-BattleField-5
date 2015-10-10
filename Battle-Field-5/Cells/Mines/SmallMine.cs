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
        /// <param name="cell">The cell which will be wrapped in mine.</param>
        public SmallMine(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets the exploding area of the mine.
        /// </summary>
        /// <returns>Positions of the tiles of the exploding area.</returns>
        public override List<Position> GetExplodingPattern()
        {
            return MineAssistant.GetNormalExplosion(this.Position, 1);
        }
    }
}
