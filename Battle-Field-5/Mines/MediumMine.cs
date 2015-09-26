namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    public class MediumMine : Mine
    {
        public MediumMine(Position position)
            : base(position)
        {
            ;
        }

        public override List<Position> Explode()
        {
            List<Position> result = MineAssistant.GetNormalExplosion(this.Position, 1);

            result.Add(new Position(base.Position.X, base.Position.Y - 2));
            result.Add(new Position(base.Position.X, base.Position.Y + 2));
            result.Add(new Position(base.Position.X - 2, base.Position.Y));
            result.Add(new Position(base.Position.X + 2, base.Position.Y));

            return result;
        }
    }
}
