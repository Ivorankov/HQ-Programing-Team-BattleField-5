//-----------------------------------------------------------------------
// <copyright file="HighscoreLogger.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains HighscoreLogger class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// A class for logging and giving access to game high scores.
    /// </summary>
    public sealed class HighscoreLogger
    {
        /// <summary>
        /// A constant for the name of the file containing the high scores.
        /// </summary>
        private const string HighscoresFileName = "highscores.xml";

        /// <summary>
        /// The instance of the <see cref="HighscoreLogger" /> class.
        /// </summary>
        private static readonly Lazy<HighscoreLogger> Lazy = new Lazy<HighscoreLogger>(() => new HighscoreLogger());

        /// <summary>
        /// Holds the game high scores.
        /// </summary>
        private List<Score> highscores;

        /// <summary>
        /// Prevents a default instance of the <see cref="HighscoreLogger" /> class from being created and loads high scores.
        /// </summary>
        private HighscoreLogger()
        {
            this.LoadHighscores();
        }

        /// <summary>
        /// Gets the <see cref="HighscoreLogger" /> class instance.
        /// </summary>
        /// <value><see cref="HighscoreLogger" /> instance.</value>
        public static HighscoreLogger Instance
        {
            get
            {
                return Lazy.Value;
            }
        }

        /// <summary>
        /// Gets the high scores.
        /// </summary>
        /// <value>High scores.</value>
        public List<Score> Highscores
        {
            get
            {
                if (this.highscores == null)
                {
                    this.highscores = new List<Score>();
                }

                return this.highscores;
            }

            private set
            {
                this.highscores = value;
            }
        }

        /// <summary>
        /// Adds a high score to the file and the list with high scores.
        /// </summary>
        /// <param name="playerName">Name of the player setting high score.</param>
        /// <param name="points">Result of the player setting the high score.</param>
        public void AddHighscore(string playerName, double points)
        {
            this.Highscores.Add(new Score(playerName, points));
            this.Highscores.Sort((x, y) => x.Points.CompareTo(y.Points));

            XmlSerializer writer = new XmlSerializer(typeof(List<Score>));

            StreamWriter file = new StreamWriter(Path.GetFullPath("../../Highscores/" + HighscoresFileName), false);

            writer.Serialize(file, this.Highscores);

            file.Close();
        }

        /// <summary>
        /// Clears all high scores.
        /// </summary>
        public void ClearHighscores()
        {
            this.Highscores.Clear();
            File.WriteAllText(Path.GetFullPath("../../Highscores/" + HighscoresFileName), string.Empty);
        }

        /// <summary>
        /// Reads high scores from the file and writes them to the list with high scores.
        /// </summary>
        public void LoadHighscores()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Score>));
            StreamReader file = new StreamReader(Path.GetFullPath("../../Highscores/" + HighscoresFileName));

            try
            {
                this.Highscores = (List<Score>)reader.Deserialize(file);
            }
            catch (InvalidOperationException)
            {
            }

            file.Close();
        }
    }
}
