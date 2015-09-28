using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class GameEngine : IGameEngine
    {
        public GameEngine(IGameRenderer renderer, IUIHhandler handler, IModel model)
        {
            this.Renderer = renderer;
            this.UIHandler = handler;
            this.Model = model;
        }

        public IGameRenderer Renderer { get; set; }

        public IUIHhandler UIHandler { get; set; }

        public IModel Model { get; set; }


        public void StartGame()
        {
            this.Renderer.ShowStartScreen();
            this.Model.FieldSize = int.Parse(this.UIHandler.TakeGameFiledSize());
            this.Model.ExplodedMinesCount = 0;
            this.Renderer.RefreshGameField();
            this.GameLoop();
        }

        private void GameLoop()
        {
            this.Model.Field = Field.GenerateField(this.Model.FieldSize);

            while (Field.ContainsMines(this.Model.Field))
            {
                this.Renderer.ShowGameScreen(this.Model.FieldSize, this.Model.Field);
                var mineToBlow = Mine.Parse(this.UIHandler.TakePositionCoordiantes());
                Mine.Explode(mineToBlow, this.Model.Field);
                this.Model.ExplodedMinesCount++;
                this.Renderer.RefreshGameField();
            }

            this.Renderer.ShowGameScreen(this.Model.FieldSize, this.Model.Field);
            this.Renderer.ShowEndScreen(this.Model.ExplodedMinesCount);
        }

        public Score score
        {
            get { throw new NotImplementedException(); }
        }
    }
}
