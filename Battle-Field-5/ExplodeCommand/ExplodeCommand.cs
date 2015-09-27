namespace BattleField.ExplodeCommand
{
    using BattleField.Enums;
    using System.Collections.Generic;

    public abstract class ExplodeCommand
    {
        public Cell Cell { get; set; }
        protected GameField field { get; private set; }

        public ExplodeCommand(GameField field)
        {
            this.field = field;
        }

        public virtual bool IsValid()
        {
            return this.Cell.Type == CellType.MINE;
        }

        public void Execute()
        {
            foreach (Position position in this.GetRelativePositions())
            {
                this.field.ExplodeCell(new Position(position.X + this.Cell.Position.X, position.Y + this.Cell.Position.Y));
            }
        }

        public abstract IEnumerable<Position> GetRelativePositions();
    }
}
