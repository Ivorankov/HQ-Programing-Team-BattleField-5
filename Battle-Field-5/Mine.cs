namespace BattleField
{
    using System;
    using System.Collections.Generic;

    public enum MineType
    {
        One,
        Two,
        Three,
        Four,
        Five
    }

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
            List<Position> result = new List<Position>();
            result.Add(new Position(this.Position.X + 1, this.Position.Y + 1));
            result.Add(new Position(this.Position.X - 1, this.Position.Y - 1));
            result.Add(new Position(this.Position.X + 1, this.Position.Y - 1));
            result.Add(new Position(this.Position.X - 1, this.Position.Y + 1));

            int mineTypeNum = (int)this.Type;
            if (mineTypeNum >= 1)
            {
                result.Add(new Position(this.Position.X, this.Position.Y + 1));
                result.Add(new Position(this.Position.X, this.Position.Y - 1));
                result.Add(new Position(this.Position.X + 1, this.Position.Y));
                result.Add(new Position(this.Position.X - 1, this.Position.Y));
            }

            if (mineTypeNum >= 2) 
            {
                result.Add(new Position(this.Position.X, this.Position.Y + 2));
                result.Add(new Position(this.Position.X, this.Position.Y - 2));
                result.Add(new Position(this.Position.X + 2, this.Position.Y));
                result.Add(new Position(this.Position.X - 2, this.Position.Y));
            }

            if (mineTypeNum >= 3) 
            {
                result.Add(new Position(this.Position.X + 2, this.Position.Y + 1));
                result.Add(new Position(this.Position.X + 2, this.Position.Y - 1));

                result.Add(new Position(this.Position.X - 2, this.Position.Y + 1));
                result.Add(new Position(this.Position.X - 2, this.Position.Y - 1));

                result.Add(new Position(this.Position.X + 1, this.Position.Y + 2));
                result.Add(new Position(this.Position.X + 1, this.Position.Y - 2));

                result.Add(new Position(this.Position.X - 1, this.Position.Y + 2));
                result.Add(new Position(this.Position.X - 1, this.Position.Y - 2));
            }

            if (mineTypeNum >= 4)
            {
                result.Add(new Position(this.Position.X + 2, this.Position.Y + 2));
                result.Add(new Position(this.Position.X - 2, this.Position.Y - 2));
                result.Add(new Position(this.Position.X + 2, this.Position.Y - 2));
                result.Add(new Position(this.Position.X - 2, this.Position.Y + 2));
            }

            return result;
        }
    }
}
