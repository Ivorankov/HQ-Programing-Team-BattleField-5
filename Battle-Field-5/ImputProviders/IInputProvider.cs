namespace MineFieldApp
{
    public interface IInputProvider
    {
        int GetFieldSize();
        Position GetPosition();
        string GetPlayerName();
    }
}
