﻿//-----------------------------------------------------------------------
// <copyright file="MediumMine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
//  Contains MediumMine class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Cells.Mines
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a MediumMine object.
    /// </summary>
    public class MediumMine : Mine
    {
        /// <summary>
        /// Initializes a new instance of the MediumMine class.
        /// </summary>
        /// <param name="cell">The cell which will be wrapped in mine.</param>
        public MediumMine(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets the exploding area of the mine.
        /// </summary>
        /// <returns>Positions of the tiles of the exploding area.</returns>
        public override List<Position> GetExplodingPattern()
        {
            List<Position> result = MineAssistant.GetNormalExplosion(this.Position, 1);

            result.Add(new Position(this.Position.Row, this.Position.Col - 2));
            result.Add(new Position(this.Position.Row, this.Position.Col + 2));
            result.Add(new Position(this.Position.Row - 2, this.Position.Col));
            result.Add(new Position(this.Position.Row + 2, this.Position.Col));

            return result;
        }
    }
}
