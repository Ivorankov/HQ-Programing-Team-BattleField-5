namespace BattleField.ExplodeCommand
{
    using BattleField.Enums;
    using System;

    public class ExplodeCommandFactory
    {
        public ExplodeCommand createExplodeCommand(GameField field, CellType type)
        {
            switch (type)
            {
                case CellType.GIANTMINE: return new SquareExplodeCommand(field, 2);
                case CellType.HUGEMINE: return new SquareExplodeCommand(field, 1); //TODO
                case CellType.BIGMINE: return new SquareExplodeCommand(field, 2); //TODO
                case CellType.SMALLMINE: return new SquareExplodeCommand(field, 1);
                case CellType.TINYMINE: return new SquareExplodeCommand(field, 2); //TODO
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
    }
}
