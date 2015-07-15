namespace BattleField
{
    using System;

    /// <summary>
    /// Represents a position in a matrix.
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Holds the value for the x coordinate.
        /// </summary>
        private int x;

        /// <summary>
        /// Holds the value for the y coordinate.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position" /> struct with specified x and y coordinates.
        /// </summary>
        /// <param name="x">Value of the X coordinate.</param>
        /// <param name="y">Value of the Y coordinate.</param>
        public Position(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the value of the X coordinate.
        /// </summary>
        public int X 
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            } 
        }

        /// <summary>
        /// Gets or sets the value of the Y coordinate.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Checks if one Position equals another Position.
        /// </summary>
        /// <param name="first">A Position to compare to second Position.</param>
        /// <param name="second">A Position to compare to first Position.</param>
        /// <returns>true if they have equal value, otherwise false.</returns>
        public static bool operator ==(Position first, Position second)
        {
            return first.Equals(second);
        }

        /// <summary>
        /// Checks if one Position does not equal another.
        /// </summary>
        /// <param name="first">A Position to compare to second Position.</param>
        /// <param name="second">A Position to compare to first Position.</param>
        /// <returns>true if they have different values, false if they have the same values</returns>
        public static bool operator !=(Position first, Position second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Checks if this Position is equal to another Position.
        /// </summary>
        /// <param name="other">A Position to compare to this Position.</param>
        /// <returns>true if the value of this Position is the same as the value of the other Position, otherwise false.</returns>
        public bool Equals(Position other)
        {
            return this.X == other.X &&
                this.Y == other.Y;
        }

        /// <summary>
        /// Checks whether this Position is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object at compare to this Position.</param>
        /// <returns>true if the value of this Position is equal to the value of the object, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Position)
            {
                return this.Equals((Position)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code of this Position.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        /// <summary>
        /// Returns a string representation of this Position.
        /// </summary>
        /// <returns>A string in the format: "X = {0}, Y = {1}"</returns>
        public override string ToString()
        {
            return string.Format("X = {0}, Y = {1}", this.X, this.Y);
        }
    }
}