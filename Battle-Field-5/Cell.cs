namespace BattleField
{
    using BattleField.Enums;
    using BattleField.ExplodeCommand;

    public class Cell
    {
        public static CellFactory CreateFactory(GameField field)
        {
            return new CellFactory(field);
        }

        public class CellFactory
        {
            private GameField field;

            public CellFactory(GameField field)
            {
                this.field = field;
            }

            public Cell CreateEmptyCell(Position position)
            {
                return new Cell(position, CellType.EMPTY, new NoneExplodeCommand());
            }
            public Cell CreateMineCell(Position position)
            {
                return new Cell(position, CellType.MINE, new GiantExplodeCommand(this.field));
            }
        }

        public Position Position { get; private set; }
        public ExplodeCommand.ExplodeCommand ExplodeCommand { get; private set; }
        public CellType Type { get; private set; }

        private Cell(Position position, CellType cellType, ExplodeCommand.ExplodeCommand explodeCommand)
        {
            this.Position = position;
            this.ExplodeCommand = explodeCommand;
            explodeCommand.Cell = this;
            this.Type = cellType;
        }

        public void ReactToExplosion()
        {
            this.Type = CellType.BOMBED;
        }
    }
}
