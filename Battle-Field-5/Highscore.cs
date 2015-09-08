namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public sealed class Highscore
    {
        private string HIGHSCORES_FILE_NAME = "highscores.xml";

        private static readonly Lazy<Highscore> lazy = new Lazy<Highscore>(() => new Highscore());

        private List<Score> highscores;

        public static Highscore Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private Highscore()
        {
            this.LoadHighscores();
        }

        public void AddHighscore(string playerName, double points)
        {
            this.Highscores.Add(new Score(playerName, points));
            this.Highscores.Sort((x, y) => y.Points.CompareTo(x.Points));

            XmlSerializer writer = new XmlSerializer(typeof(List<Score>));

            StreamWriter file = new StreamWriter(Path.GetFullPath(HIGHSCORES_FILE_NAME), false);

            writer.Serialize(file, this.Highscores);

            file.Close();
        }

        private void LoadHighscores()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Score>));
            StreamReader file = new StreamReader(Path.GetFullPath(HIGHSCORES_FILE_NAME));

            try
            {
                this.Highscores = (List<Score>)reader.Deserialize(file);
            }
            catch (InvalidOperationException)
            {

            }

            file.Close();
        }

        public void ClearHighscores()
        {
            this.Highscores.Clear();
            File.WriteAllText(Path.GetFullPath(HIGHSCORES_FILE_NAME), String.Empty);
        }

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
    }
}
