namespace MineFieldApp
{
    using Cells;
    using Cells.Mines;
    using MineFieldApp.Data;
    using MineFieldApp.Renderer;

    public class Engine : IEngine
    {
        private IRenderer renderer;

        private GameField field;

        private int movesCount;

        private ICellDamageHandler damageHandler;

        public Engine(IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        public void Init(GameField field)
        {
            this.field = field;
            this.movesCount = 0;
            this.renderer.ShowGameField(field);
        }

        public void UpdateField(Position pos)
        {
            Position position = pos;

            if (this.field.IsInRange(position) && (this.field[position.Row, position.Col] is Mine))
            {
                this.movesCount++;
                Mine mine = this.field[position.Row, position.Col] as Mine;
                this.field.ReactToExplosion(mine.GetExplodingPattern(), this.damageHandler);
                this.renderer.RefreshGameField();
            }
            else
            {
                this.renderer.ShowErrorMessage("Invalid coordinates or the selected cell is not a mine.");
            }

            if (!this.field.HasMinesLeft())
            {
                this.GameOver();
            }
        }

        public void GameOver()
        {
            var data = new GameObjData(this.field, this.movesCount);
            this.renderer.ShowGameOver(data);
            this.renderer.ShowHighscores(data);
        }
    }
}