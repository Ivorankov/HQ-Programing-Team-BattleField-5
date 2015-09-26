namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    public class GiantMine : Mine
    {
        public GiantMine(Position position)
            : base(position)
        {
            ;
        }

        public override List<Position> Explode()
        {
            return MineAssistant.GetNormalExplosion(base.Position, 2);
        }
    }
}
