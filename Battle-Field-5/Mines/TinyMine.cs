namespace MineFieldApp.Mines
{
    using System.Collections.Generic;

    public class TinyMine : Mine
    {
        public TinyMine(Position position)
            :base(position)
        {
            ;
        }

        public sealed override List<Position> Explode()
        {
            List<Position> result = new List<Position>();

            result.Add(this.Position);
            result.Add(new Position(base.Position.X - 1, base.Position.Y - 1));
            result.Add(new Position(base.Position.X + 1, base.Position.Y + 1));
            result.Add(new Position(base.Position.X + 1, base.Position.Y - 1));
            result.Add(new Position(base.Position.X - 1, base.Position.Y + 1));

            return result;
        }
    }
}