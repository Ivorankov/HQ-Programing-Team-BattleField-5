namespace BattleField
{
    using System;

    public struct Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Position)
            {
                return this.Equals((Position)obj);
            }

            return false;
        }

        public bool Equals(Position other)
        {

            return this.X == other.X &&
                this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public override string ToString()
        {
            return string.Format("X = {0}, Y = {1}", this.X, this.Y);
        }

        public static bool operator ==(Position first, Position second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Position first, Position second)
        {
            return !(first == second);
        }
    }
}