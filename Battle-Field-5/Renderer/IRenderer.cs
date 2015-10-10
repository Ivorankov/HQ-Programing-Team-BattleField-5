namespace MineFieldApp.Renderer
{
    using System;
    using MineFieldApp.Data;

    public interface IRenderer
    {
        event EventHandler<PositionEventArg> InputPosition;

        void ShowWelcome();

        void ShowGameField(GameField field);

        void RefreshGameField(GameField field);

        void ShowErrorMessage(string message);

        void ShowHighscores();

        void ShowGameOver(GameData data);
    }
}
