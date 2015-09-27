namespace BattleField.ExplodeCommand
{
    using BattleField.Enums;
    using System;

    public class ExplodeCommandFactory
    {
        public ExplodeCommand createExplodeCommand(GameField field, ExplosionType type)
        {
            switch (type)
            {
                case ExplosionType.GIANT: return new SquareExplodeCommand(field, 2);
                case ExplosionType.HUGE: // TODO
                case ExplosionType.BIG: // TODO
                case ExplosionType.SMALL: return new SquareExplodeCommand(field, 1);
                case ExplosionType.TINY: // TODO
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
    }
}
