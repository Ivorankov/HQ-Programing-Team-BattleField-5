namespace BattleField.ExplodeCommand
{
    using System.Collections.Generic;

    public class SquareExplodeCommand : ExplodeCommand
    {
        private int radius;

        public SquareExplodeCommand(GameField field, int radius) : base(field) {
            this.radius = radius;
        }
        public SquareExplodeCommand(GameField field)
            : base(field) { }

        protected override IEnumerable<Position> GetRelativePositions()
        {
            List<Position> positions = new List<Position>();
            for (int row = -this.radius; row <= this.radius; row++)
            {
                for (int column = -this.radius; column <= this.radius; column++)
                {
                    positions.Add(new Position(row, column));
                }
            }

            return positions;
        }
    }
}
