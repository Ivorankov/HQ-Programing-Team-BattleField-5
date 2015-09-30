//-----------------------------------------------------------------------
// <copyright file="Highscore.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains Highscore class
// </summary>
//-----------------------------------------------------------------------
namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// A class for logging and giving access to game highscores
    /// </summary>
    public sealed class HighscoreLogger
    {
        /// <summary>
        /// A constant for the name of the file containing the highscores
        /// </summary>
        private const string HighscoresFileName = "highscores.xml";

        /// <summary>
        /// The instance of the Highscore class
        /// </summary>
        private static readonly Lazy<HighscoreLogger> Lazy = new Lazy<HighscoreLogger>(() => new HighscoreLogger());

        /// <summary>
        /// Holds the game highscores
        /// </summary>
        private List<Score> highscores;

        /// <summary>
        /// Initializes a new instance of the Highscore class and loads highscores
        /// </summary>
        private HighscoreLogger()
        {
            this.LoadHighscores();
        }

        /// <summary>
        /// Gets the Highscore class instance
        /// </summary>
        public static HighscoreLogger Instance
        {
            get
            {
                return Lazy.Value;
            }
        }

        /// <summary>
        /// Gets or sets the highscores.
        /// </summary>
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
        /// Adds a highscore to the file and a the list with highscores
        /// </summary>
        /// <param name="playerName">Name of the player setting high score</param>
        /// <param name="points">His result</param>
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
        /// Clears all highscores
        /// </summary>
        public void ClearHighscores()
        {
            this.Highscores.Clear();
            File.WriteAllText(Path.GetFullPath("../../Highscores/" + HighscoresFileName), string.Empty);
        }

        /// <summary>
        /// Reads highscores from the file and writes them to the list with highscores
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
