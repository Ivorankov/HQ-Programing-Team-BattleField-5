namespace MineFieldApp
{
    using System;

    public class Score
    {
        private string playerName;
        private double points;
        private DateTime date;

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

        public Score(string playerName, double points)
        {
            this.PlayerName = playerName;
            this.Points = points;
            this.Date = DateTime.Now;
        }

        public Score()
        {

        }
    }
}
