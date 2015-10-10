namespace MineFieldApp.Engines
{
    using Renderer;
    using Cells;
    using Cells.Mines;
    using Data;

    public class Engine : IEngine
    {
        private IRenderer renderer;

        private GameField field;

        public int MovesCount {get; private set;}

        private ICellDamageHandler damageHandler;

        public Engine(IRenderer renderer, ICellDamageHandler damageHandler)
        {
            this.renderer = renderer;
            this.damageHandler = damageHandler;
        }

        public void Init(GameField field)
        {
            this.field = field;
            this.MovesCount = 0;
            this.renderer.InputPosition += (rendererObj, positionArg) =>
            {
                this.UpdateField(positionArg.Position);
            };

            this.renderer.ShowGameField(field);
        }

        public void UpdateField(Position pos)
        {
            Position position = pos;

            if (this.field.IsInRange(position) && (this.field[position.Row, position.Col] is Mine))
            {
                this.MovesCount++;
                Mine mine = this.field[position.Row, position.Col] as Mine;
                this.field.ReactToExplosion(mine.GetExplodingPattern(), this.damageHandler);
            }
            else
            {
                this.renderer.ShowErrorMessage("Invalid coordinates or the selected cell is not a mine.");
            }

            if (this.field.HasMinesLeft())
            {
                this.renderer.RefreshGameField(field);
            }
            else
            {
                this.GameOver();
            }
        }

        public void GameOver()
        {
            var gameData = new GameData(this.field, this.MovesCount, this.damageHandler);
            this.renderer.ShowGameOver(gameData);
        }

        public GameData CreateMemento()
        {
            return new GameData(this.field, this.MovesCount, this.damageHandler);
        }

        public void SetMemento(GameData memento)
        {
            this.field = memento.GameField;
            this.MovesCount = memento.MovesCount;
            this.damageHandler = memento.DamageHandler;
        }
    }
}