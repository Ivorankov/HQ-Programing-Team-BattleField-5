﻿//-----------------------------------------------------------------------
// <copyright file="BigMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
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
        protected override List<Position> GetExplodingPattern()
        {
            List<Position> result = new List<Position>();

            const int Radius = 2;
            int startRow = this.Position.Row - Radius;
            int startCol = this.Position.Col - Radius;
            int explosionSize = 2 * Radius;
            int endRow = startRow + explosionSize;
            int endCol = startCol + explosionSize;
            for (int x = startRow; x <= endRow; x++)
            {
                for (int y = startCol; y <= endCol; y++)
                {
                    if (((x == startRow) && (y == startCol)) ||
                        ((x == endRow) && (y == endCol)) ||
                        ((x == startRow) && (y == endCol)) ||
                        ((x == endRow) && (y == startCol)))
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