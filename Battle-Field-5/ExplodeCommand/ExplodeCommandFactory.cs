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
                case CellType.HUGEMINE: return new HugeExplodeCommand(field);
                case CellType.BIGMINE: return new BigExplodeCommand(field);
                case CellType.SMALLMINE: return new SquareExplodeCommand(field, 1);
                case CellType.TINYMINE: return new TinyExplodeCommand(field);
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
    }
}
