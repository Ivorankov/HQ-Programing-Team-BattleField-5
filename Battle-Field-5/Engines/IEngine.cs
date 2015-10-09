namespace MineFieldApp.Engines
{
    using Data;
    
    public interface IEngine
    {
        void Init(GameField field);

        void UpdateField(Position position);

        void GameOver();

        GameData CreateMemento();

        void SetMemento(GameData memento);
    }
}
