namespace MineFieldApp.Renderer
{
    using MineFieldApp.Data;
    using System;

    public interface IRenderer
    {
        void ShowGameField(GameField field);

        void RefreshGameField(GameField field);

        void ShowHighscores(GameObjData data);

        void ShowGameOver(GameObjData data);

        void ShowErrorMessage(string message);
    }
}