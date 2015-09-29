﻿//-----------------------------------------------------------------------
// <copyright file="MineAssistant.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// An object which holds common methods and values for Mine objects.
    /// </summary>
    public static class MineAssistant
    {
        /// <summary>
        /// Generates a square explosion pattern around a center position.
        /// </summary>
        /// <param name="center">The center position of the pattern.</param>
        /// <param name="radius">The radius of the pattern.</param>
        /// <returns>List containing the positions of the tiles of the exploding area.</returns>
        public static List<Position> GetNormalExplosion(Position center, int radius)
        {
            List<Position> result = new List<Position>();

            int startX = center.X - radius;
            int startY = center.Y - radius;
            int explosionSize = (2 * radius) + 1;
            for (int x = startX; x < (startX + explosionSize); x++)
            {
                for (int y = startY; y < (startY + explosionSize); y++)
                {
                    result.Add(new Position(x, y));
                }
            }

            return result;
        }
    }
}