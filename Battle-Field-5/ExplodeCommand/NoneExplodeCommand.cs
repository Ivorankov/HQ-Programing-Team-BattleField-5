namespace BattleField.ExplodeCommand
{
    using System;
    using System.Collections.Generic;

    public sealed class NoneExplodeCommand : ExplodeCommand
    {
        public NoneExplodeCommand() : base(null) { }

        public override bool IsValid()
        {
            return false;
        }

        protected override IEnumerable<Position> GetRelativePositions()
        {
            throw new NotSupportedException();
        }
    }
}
