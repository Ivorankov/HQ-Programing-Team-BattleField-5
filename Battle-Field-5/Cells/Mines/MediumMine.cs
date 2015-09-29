//-----------------------------------------------------------------------
// <copyright file="MediumMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a MediumMine object.
    /// </summary>
    public class MediumMine : Mine
    {
        public MediumMine(ICellDamageHandler damageHandler, Position position)
            : base(damageHandler, position)
        {

        }

        /// <summary>
        /// Initializes a new instance of the MediumMine class.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        public MediumMine(Position position)
            : base(position)
        {
        }

        /// <summary>
        /// The method returns the exploding area of the mine.
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area.</returns>
        protected override List<Position> GetExplodingPattern()
        {
            List<Position> result = MineAssistant.GetNormalExplosion(this.Position, 1);

            result.Add(new Position(this.Position.X, this.Position.Y - 2));
            result.Add(new Position(this.Position.X, this.Position.Y + 2));
            result.Add(new Position(this.Position.X - 2, this.Position.Y));
            result.Add(new Position(this.Position.X + 2, this.Position.Y));

            return result;
        }
    }
}
