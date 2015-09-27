//-----------------------------------------------------------------------
// <copyright file="GiantMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Mines
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
        /// <param name="position">The position of the mine.</param>
        public GiantMine(Position position)
            : base(position)
        {
        }

        /// <summary>
        /// The method returns the exploding area of the mine.
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area.</returns>
        public override List<Position> Explode()
        {
            return MineAssistant.GetNormalExplosion(this.Position, 2);
        }
    }
}
