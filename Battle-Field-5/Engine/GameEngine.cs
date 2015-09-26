using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class GameEngine : IGameEngine
    {
        private IGameRenderer renderer;

        public GameEngine(IGameRenderer renderer, Score score)
        {
            this.renderer = renderer;

        }


        public void StartGame()
        {
            renderer.ShowStartScreen();
        }

        private void GameLoop()
        {

        }

        public Score score
        {
            get { throw new NotImplementedException(); }
        }
    }
}
