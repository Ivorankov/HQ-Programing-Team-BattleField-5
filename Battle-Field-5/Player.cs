namespace BattleField
{
    using System;

    public class Player
    {
        private const byte PlayerNameMinLength = 3;
        private const byte PlayerNameMaxLength = 20;

        private string name;
        private int points;

        public Player(string name)
        {
            this.Name = name;
            this.Points = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's name can not be null or empty.");
                }

                if (value.Length < PlayerNameMinLength || value.Length > PlayerNameMaxLength)
                {
                    throw new ArgumentOutOfRangeException("Player's name must be between 3 and 20 symbols long.");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            protected set
            {
                this.points = value;
            }
        }
    }
}