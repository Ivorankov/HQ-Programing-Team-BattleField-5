//-----------------------------------------------------------------------
// <copyright file="Mine.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleField
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a mine object
    /// </summary>
    public class Mine
    {
        /// <summary>
        /// Initializes a new instance of the Mine class
        /// </summary>
        /// <param name="type">Type of the mine</param>
        /// <param name="position">The position of the mine</param>
        public Mine(MineType type, Position position)
        {
            this.Type = type;
            this.Position = position;
        }

        /// <summary>
        /// Gets or sets mine position
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets mine type
        /// </summary>
        public MineType Type { get; set; }

        /// <summary>
        /// The method returns the exploding area of the mine
        /// </summary>
        /// <returns>List containing the positions of the tiles of the exploding area</returns>
        public List<Position> GetExplodingArea()
        {
            List<Position> explosionAreaTilesPosition = new List<Position>();

            explosionAreaTilesPosition.Add(new Position(this.Position.X, this.Position.Y));
            explosionAreaTilesPosition.Add(new Position(this.Position.X + 1, this.Position.Y + 1));
            explosionAreaTilesPosition.Add(new Position(this.Position.X - 1, this.Position.Y - 1));
            explosionAreaTilesPosition.Add(new Position(this.Position.X + 1, this.Position.Y - 1));
            explosionAreaTilesPosition.Add(new Position(this.Position.X - 1, this.Position.Y + 1));

            int mineType = (int)this.Type;

            if (mineType >= 2)
            {
                explosionAreaTilesPosition.Add(new Position(this.Position.X, this.Position.Y + 1));
                explosionAreaTilesPosition.Add(new Position(this.Position.X, this.Position.Y - 1));
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 1, this.Position.Y));
                explosionAreaTilesPosition.Add(new Position(this.Position.X - 1, this.Position.Y));
            }

            if (mineType >= 3) 
            {
                explosionAreaTilesPosition.Add(new Position(this.Position.X, this.Position.Y + 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X, this.Position.Y - 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 2, this.Position.Y));
                explosionAreaTilesPosition.Add(new Position(this.Position.X - 2, this.Position.Y));
            }

            if (mineType >= 4) 
            {
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 2, this.Position.Y + 1));
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 2, this.Position.Y - 1));

                explosionAreaTilesPosition.Add(new Position(this.Position.X - 2, this.Position.Y + 1));
                explosionAreaTilesPosition.Add(new Position(this.Position.X - 2, this.Position.Y - 1));

                explosionAreaTilesPosition.Add(new Position(this.Position.X + 1, this.Position.Y + 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 1, this.Position.Y - 2));

                explosionAreaTilesPosition.Add(new Position(this.Position.X - 1, this.Position.Y + 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X - 1, this.Position.Y - 2));
            }

            if (mineType >= 5)
            {
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 2, this.Position.Y + 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X - 2, this.Position.Y - 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X + 2, this.Position.Y - 2));
                explosionAreaTilesPosition.Add(new Position(this.Position.X - 2, this.Position.Y + 2));
            }

            return explosionAreaTilesPosition;
        }
    }
}
