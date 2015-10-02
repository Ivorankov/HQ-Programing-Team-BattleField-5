namespace BattleField.Renderer
{
    using BattleField.Data;
    using System;

    public interface IRenderer
    {
        void SayWelcome();
        void ShowErrorMessage(String message);
        void ShowGameField(GameField field);
        void ShowHighscores();
        void ShowGameOver(GameObjData data);
        void Clear();
    }
}
