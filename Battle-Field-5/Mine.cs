namespace BattleField
{
    using System.Collections.Generic;

    public class Mine
    {
        public Mine(MineType type, Position position)
        {
            this.Type = type;
            this.Position = position;
        }

        public Position Position { get; set; }

        public MineType Type { get; set; }

        public List<Position> Explode()
        {
            List<Position> explosionAreaTilesPosition = new List<Position>();

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
