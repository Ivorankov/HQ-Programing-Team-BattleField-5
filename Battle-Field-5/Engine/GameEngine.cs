using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class GameEngine : IGameEngine
    {
        private IGameRenderer renderer;

        private IUIHhandler handler;

        public GameEngine(IGameRenderer renderer, IUIHhandler handler)
        {
            this.renderer = renderer;
            this.handler = handler;
        }


        public void StartGame()
        {
            renderer.ShowStartScreen();
            renderer.FieldSize = int.Parse(handler.TakeGameFiledSize());
            renderer.Clear();
            this.GameLoop();
        }

        private void GameLoop()
        {
            var field = Field.GenerateField(renderer.FieldSize);

            int explodedMinesCount = 0;
            while (Field.ContainsMines(field))
            {
                renderer.DrawGameField(renderer.FieldSize, field);
                var mineToBlow = Mine.Parse(handler.TakePositionCoordiantes());
                Mine.Explode(mineToBlow, field);
                explodedMinesCount++;
                renderer.Clear();
            }

            renderer.DrawGameField(renderer.FieldSize, field);
            renderer.ShowEndScreen();
        }

        public Score score
        {
            get { throw new NotImplementedException(); }
        }
    }
}
