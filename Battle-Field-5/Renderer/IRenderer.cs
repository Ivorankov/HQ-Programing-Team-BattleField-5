namespace BattleField.Renderer
{
    using System;

    public interface IRenderer
    {
        void SayWelcome();
        void ShowErrorMessage(String message);
        void ShowGameField(GameField field);
        void Clear();
    }
}
