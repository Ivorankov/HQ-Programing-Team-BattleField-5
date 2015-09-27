namespace BattleField.ExplodeCommand
{
    using System.Collections.Generic;

    public class GiantExplodeCommand : ExplodeCommand
    {
        public GiantExplodeCommand(GameField field)
            : base(field) { }

        public override IEnumerable<Position> GetRelativePositions()
        {
            List<Position> positions = new List<Position>();
            for (int row = -2; row <= 2; row++)
            {
                for (int column = -2; column <= 2; column++)
                {
                    positions.Add(new Position(row, column));
                }
            }

            return positions;
        }
    }
}
