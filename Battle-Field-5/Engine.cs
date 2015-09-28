﻿namespace BattleField
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

            while (this.field.HasMinesLeft())
            {
                this.renderer.ShowGameField(field);
                Position position = this.inputProvider.GetPosition();
                this.renderer.Clear();

                //isnt it better to check this way(KISS):   this.field[position.X, position.Y].Type == CellType.MINE
                if (this.field.IsInRange(position) && this.field[position.X, position.Y].ExplodeCommand.IsValid())
                {
                    this.field.ActivateMine(position);
                }
                else
                {
                    this.renderer.ShowErrorMessage("Invalid coordinates or the selected cell is not a mine.");
                }
            }

            this.renderer.FinishGame();
        }


    }
}