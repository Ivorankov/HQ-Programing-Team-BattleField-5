namespace BattleField.Renderer
{
    using System;
    using System.Collections.Generic;

    public interface IRenderer
    {
        void SayWelcome();
        void ShowErrorMessage(String message);
        void ShowGameField(GameField field);
        void ShowHighscores(IList<Score> highscores);
        void Clear();
    }
}
