//-----------------------------------------------------------------------
// <copyright file="Score.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains Score class
// </summary>
//-----------------------------------------------------------------------
namespace BattleField
{
    using System;

    /// <summary>
    /// Class representing a players score
    /// </summary>
    public class Score
    {
        /// <summary>
        /// Holds the value of players name
        /// </summary>
        private string playerName;

        /// <summary>
        /// Holds the value of players points 
        /// </summary>
        private double points;

        /// <summary>
        /// Holds the date of creation of the score
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Initializes a new instance of the Score class
        /// </summary>
        /// <param name="playerName">The name of the player</param>
        /// <param name="points">The points of the player</param>
        public Score(string playerName, double points)
        {
            this.PlayerName = playerName;
            this.Points = points;
            this.Date = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the Score class. This emplty constructor
        /// is obligatory because of the serialization.
        /// </summary>
        public Score()
        {
        }

        /// <summary>
        /// Gets or sets players name
        /// </summary>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            set
            {
                this.playerName = value;
            }
        }

        /// <summary>
        /// Gets or sets points
        /// </summary>
        public double Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }

        /// <summary>
        /// Gets or sets scores data
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }
    }
}
