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
        /// <param name="position">The position of the mine.</param>
        public TinyMine(Position position, GameField field)
            : base(position, field)
        {
        }

        /// <summary>
        /// The method returns the exploding area of the mine.
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area.</returns>
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