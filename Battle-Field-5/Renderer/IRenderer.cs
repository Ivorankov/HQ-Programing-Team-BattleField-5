namespace MineFieldApp.Renderer
{
    using MineFieldApp.Data;
    using System;

    public interface IRenderer
    {
        void ShowErrorMessage(String message);
        void ShowGameField(GameField field);
        void ShowHighscores(GameObjData data);
        void ShowGameOver(GameObjData data);
        void RefreshGameField();
    }
}
