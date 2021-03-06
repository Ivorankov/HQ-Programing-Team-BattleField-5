﻿namespace MineFieldApp.Data
{
    public class GameObjData
    {
        public int MovesCount { get; private set; }

        public GameField GameField { get; private set; }

        public GameObjData(GameField gameField, int movesCount)
        {
            this.GameField = gameField;
            this.MovesCount = movesCount;
        }
    }
}
