namespace BattleField
{
    using BattleField.Renderer;
    using System;

    public class Engine
    {
        private GameField field;
        private IInputProvider inputProvider;
        private IRenderer renderer;

        public Engine(IInputProvider inputProvider, IRenderer renderer)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
        }

        public void Start()
        {
            int fieldSize = this.inputProvider.GetFieldSize();
            this.field = new GameField(fieldSize);
            this.renderer.Clear();

            while (true)
            {
                this.renderer.ShowGameField(field);
                Position position = this.inputProvider.GetPosition();
                if (this.field.IsInRange(position) && this.field[position.X, position.Y].ExplodeCommand.IsValid())
                {
                    this.field[position.X, position.Y].ExplodeCommand.Execute();
                    this.renderer.Clear();
                }
                else
                {
                    this.renderer.Clear();
                    Console.WriteLine("Invalid input!");
                }
            }
        }


    }
}