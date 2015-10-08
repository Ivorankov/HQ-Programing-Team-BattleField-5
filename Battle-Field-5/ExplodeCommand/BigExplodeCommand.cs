namespace MineFieldApp.ExplodeCommand
{
    using System;
    using System.Collections.Generic;

    public class BigExplodeCommand : ExplodeCommand
    {
        private int RADIUS = 2;

        public BigExplodeCommand(GameField field)
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
                    if ((Math.Abs(row) == RADIUS && column != 0) || (Math.Abs(column) == RADIUS && row != 0))
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
