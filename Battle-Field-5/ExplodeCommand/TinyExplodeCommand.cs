namespace MineFieldApp.ExplodeCommand
{
    using System;
    using System.Collections.Generic;

    public class TinyExplodeCommand : ExplodeCommand
    {
        private const int RADIUS = 1;

        public TinyExplodeCommand(GameField field)
            : base(field)
        {
        }

        protected override IEnumerable<Position> GetRelativePositions()
        {
            List<Position> positions = new List<Position>();
            for (int row = -RADIUS; row <= RADIUS; row++)
            {
                for (int column = -RADIUS; column <= RADIUS; column++)
                {
                    if (Math.Abs(row) != Math.Abs(column))
                    {
                        continue;
                    }
                    positions.Add(new Position(row, column));
                }
            }

            return positions;
        }
    }
}
