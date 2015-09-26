namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    public class BigMine : Mine
    {
        public BigMine(Position position)
            : base(position)
        {
            ;
        }

        public override List<Position> Explode()
        {
            List<Position> result = new List<Position>();

            const int radius = 2;
            int startX = base.Position.X - radius;
            int startY = base.Position.Y - radius;
            int explosionSize = 2 * radius;
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
