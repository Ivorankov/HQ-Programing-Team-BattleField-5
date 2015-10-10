namespace MineFieldApp.Renderer
{
    using MineFieldApp.Data;
    using System;

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
