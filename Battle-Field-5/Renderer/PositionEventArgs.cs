namespace MineFieldApp.Renderer
{
    using System;

    public class PositionEventArg : EventArgs
    {
        public PositionEventArg(Position position)
            : base()
        {
            this.Position = position;
        }

        public Position Position { get; private set; }
    }
}