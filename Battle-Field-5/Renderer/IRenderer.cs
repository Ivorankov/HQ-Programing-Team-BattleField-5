namespace BattleField.Renderer
{
    public interface IRenderer
    {
        void SayWelcome();
        void ShowGameField(GameField field);
        void Clear();
    }
}
