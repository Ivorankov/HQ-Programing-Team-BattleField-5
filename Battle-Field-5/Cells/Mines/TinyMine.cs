//-----------------------------------------------------------------------
// <copyright file="TinyMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a TinyMine object.
    /// </summary>
    public class TinyMine : Mine
    {
        /// <summary>
        /// Initializes a new instance of the TinyMine class.
        /// </summary>
        /// <param name="cell">The cell which will be wrapped in mine.</param>
        public TinyMine(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets the exploding area of the mine.
        /// </summary>
        /// <returns>Positions of the tiles of the exploding area.</returns>
        public override List<Position> GetExplodingPattern()
        {
            List<Position> result = new List<Position>();

            result.Add(this.Position);
            result.Add(new Position(this.Position.Row - 1, this.Position.Col - 1));
            result.Add(new Position(this.Position.Row + 1, this.Position.Col + 1));
            result.Add(new Position(this.Position.Row + 1, this.Position.Col - 1));
            result.Add(new Position(this.Position.Row - 1, this.Position.Col + 1));

            return result;
        }
    }
}