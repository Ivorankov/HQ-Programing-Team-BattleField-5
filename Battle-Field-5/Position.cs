namespace BattleField
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override int GetHashCode()
        {
            return this.X * 17 + this.Y;
        }

        public override bool Equals(object obj)
        {
            Position other = obj as Position;
            return other != null && this.X == other.X && this.Y == other.Y;
        }
    }
}
