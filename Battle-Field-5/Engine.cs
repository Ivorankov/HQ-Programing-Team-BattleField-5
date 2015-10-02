namespace BattleField
{
    using BattleField.Data;
    using BattleField.Renderer;
    using System.Timers;

    public class Engine
    {
        public GameField field;
        public IRenderer renderer;
        private int movesCount;

        public Engine(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Start(int fieldSize)
        {
            this.renderer.SayWelcome();
            this.field = new GameField(fieldSize);
            this.movesCount = 0;
            this.renderer.ShowGameField(field);
        }

        private void GameOver()
        {

        }

        private void PersistResult()
        {
            string playerName = "Test";
            HighscoreLogger.Instance.AddHighscore(playerName, this.movesCount);
        }

        public void UpdateField(Position pos)// while loops do not work with event driven tech... on event trigger from UI this method is called
        {
            Position position = pos;
            this.renderer.Clear();

            //isnt it better to check this way(KISS):   this.field[position.X, position.Y].Type == CellType.MINE
            if (this.field.IsInRange(position) && this.field[position.X, position.Y].ExplodeCommand.IsValid())
            {
                ++this.movesCount;
                this.field.ActivateMine(position);
                this.renderer.Clear();
            }
            else
            {
                this.renderer.ShowErrorMessage("Invalid coordinates or the selected cell is not a mine.");
            }

            if (!this.field.HasMinesLeft())
            {
                var dataTest = new GameObjData(this.field, this.movesCount);
                this.renderer.ShowGameOver(dataTest);
            }
        }
    }
}