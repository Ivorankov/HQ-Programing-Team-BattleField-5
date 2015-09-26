namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    public class SmallMine : Mine
    {
        public SmallMine(Position position)
            : base(position)
        {
            ;
        }

        public override List<Position> Explode()
        {
            return MineAssistant.GetNormalExplosion(base.Position, 1);
        }
    }
}
