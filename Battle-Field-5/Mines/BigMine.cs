//-----------------------------------------------------------------------
// <copyright file="BigMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a BigMine object.
    /// </summary>
    public class BigMine : Mine
    {
        /// <summary>
        /// Initializes a new instance of the BigMine class.
        /// </summary>
        /// <param name="position">The position of the mine.</param>
        public BigMine(Position position)
            : base(position)
        {
        }

        /// <summary>
        /// The method returns the exploding area of the mine.
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area.</returns>
        public override List<Position> Explode()
        {
            List<Position> result = new List<Position>();

            const int Radius = 2;
            int startX = this.Position.X - Radius;
            int startY = this.Position.Y - Radius;
            int explosionSize = 2 * Radius;
            int endX = startX + explosionSize;
            int endY = startY + explosionSize;
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (((x == startX) && (y == startY)) ||
                        ((x == endX) && (y == endY)) ||
                        ((x == startX) && (y == endY)) ||
                        ((x == endX) && (y == startY)))
                    {
                        continue;
                    }

                    result.Add(new Position(x, y));
                }
            }

            return result;
        }
    }
}
