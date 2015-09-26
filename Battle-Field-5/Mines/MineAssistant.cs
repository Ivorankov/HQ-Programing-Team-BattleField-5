namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    public static class MineAssistant
    {
        public static List<Position> GetNormalExplosion(Position position, int radius)
        {
            List<Position> result = new List<Position>();

            int startX = position.X - radius;
            int startY = position.Y - radius;
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