namespace BattleField
{
    using BattleField.Renderer;

    public class Engine
    {
        private GameField field;
        private IInputProvider inputProvider;
        private IRenderer renderer;
        private int MovesCount;

        public Engine(IInputProvider inputProvider, IRenderer renderer)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
        }

        public void Start()
        {
            this.renderer.SayWelcome();
            int fieldSize = this.inputProvider.GetFieldSize();
            this.field = new GameField(fieldSize);
            this.MovesCount = 0;
            this.renderer.Clear();

            while (this.field.HasMinesLeft())
            {
                this.renderer.ShowGameField(field);
                Position position = this.inputProvider.GetPosition();
                this.renderer.Clear();

                //isnt it better to check this way(KISS):   this.field[position.X, position.Y].Type == CellType.MINE
                if (this.field.IsInRange(position) && this.field[position.X, position.Y].ExplodeCommand.IsValid())
                {
                    ++this.MovesCount;
                    this.field.ActivateMine(position);
                }
                else
                {
                    this.renderer.ShowErrorMessage("Invalid coordinates or the selected cell is not a mine.");
                }
            }

            this.GameOver();
            this.PersistResult();
            this.renderer.ShowHighscores();
        }

        private void GameOver()
        {
            this.renderer.ShowGameOver();
        }

        private void PersistResult()
        {
            string playerName = this.inputProvider.GetPlayerName();
            Highscore.Instance.AddHighscore(playerName, this.MovesCount);
        }

    }
}