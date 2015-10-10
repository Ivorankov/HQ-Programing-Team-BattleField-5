//-----------------------------------------------------------------------
// <copyright file="GiantMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains GiantMine class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a GiantMine object.
    /// </summary>
    public class GiantMine : Mine
    {
        /// <summary>
        /// Initializes a new instance of the GiantMine class.
        /// </summary>
        /// <param name="cell">The cell which will be wrapped in mine.</param>
        public GiantMine(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets the exploding area of the mine.
        /// </summary>
        /// <returns>Positions of the tiles of the exploding area.</returns>
        public override List<Position> GetExplodingPattern()
        {
            return MineAssistant.GetNormalExplosion(this.Position, 2);
        }
    }
}
