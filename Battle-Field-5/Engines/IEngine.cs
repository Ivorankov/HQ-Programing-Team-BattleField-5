﻿using MineFieldApp.Renderer;
using System;

namespace MineFieldApp
{
   public interface IEngine
    {
        void Init(GameField field);
        void UpdateField(Position position);
        void GameOver();

    }
}
