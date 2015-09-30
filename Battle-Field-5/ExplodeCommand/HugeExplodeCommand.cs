namespace BattleField.ExplodeCommand
{
    using System;
    using System.Collections.Generic;

    public class HugeExplodeCommand : ExplodeCommand
    {
        private const int RADIUS = 2;

        public HugeExplodeCommand(GameField field)
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
                    if (Math.Abs(row) == RADIUS && Math.Abs(column) == RADIUS)
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
