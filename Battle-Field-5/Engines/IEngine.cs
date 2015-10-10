namespace MineFieldApp.Engines
{
    using Data;

    public interface IEngine
    {
        int MovesCount { get; }

        void Init(GameField field);

        void UpdateField(Position position);

        void GameOver();

        GameData CreateMemento();

        void SetMemento(GameData memento);
    }
}
