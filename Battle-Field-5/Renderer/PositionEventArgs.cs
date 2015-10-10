//-----------------------------------------------------------------------
// <copyright file="PositionEventArgs.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains PositionEventArgs class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Renderer
{
    using System;

    /// <summary>
    /// Represents a class for position event data.
    /// </summary>
    public class PositionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionEventArgs" /> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public PositionEventArgs(Position position)
            : base()
        {
            this.Position = position;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; private set; }
    }
}