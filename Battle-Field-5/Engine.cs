namespace MineFieldApp
{
    using MineFieldApp.Renderer;

    using Cells.Mines;
    using Cells;

    public class Engine
    {
        private IInputProvider inputProvider;

        private IRenderer renderer;

        private GameField field;

        private int MovesCount;

        private ICellDamageHandler damageHandler;

        public Engine(IInputProvider inputProvider, IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        public void Start()
        {  
            this.renderer.SayWelcome();
            var fieldSize = this.inputProvider.GetFieldSize();
            this.field = new GameField(fieldSize);         
            this.MovesCount = 0;
            this.renderer.Clear();

            System.Console.WriteLine(this.field.MinesCount);

            while (this.field.HasMinesLeft())
            {
                this.renderer.ShowGameField(field);
                Position position = this.inputProvider.GetPosition();
                this.renderer.Clear();
                
                if (this.field.IsInRange(position) && (this.field[position.Row, position.Col] is Mine))
                {
                    this.MovesCount++;
                    Mine mine = this.field[position.Row, position.Col] as Mine;
                    this.field.ReactToExplosion(mine.GetExplodingPattern(), damageHandler);
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
            HighscoreLogger.Instance.AddHighscore(playerName, this.MovesCount);
        }

    }
}