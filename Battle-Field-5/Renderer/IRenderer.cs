namespace MineFieldApp.Renderer
{
    using MineFieldApp.Data;
    using System;

    public interface IRenderer
    {
        event EventHandler<PositionEventArg> InputPosition;

        void ShowGameField(GameField field);

        void RefreshGameField(GameField field);


        void ShowErrorMessage(string message);

        void ShowHighscores(GameData data);

        void ShowGameOver(GameData data);
    }
}
