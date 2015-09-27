namespace BattleField.ExplodeCommand
{
    public interface ICommand
    {

        bool IsValid();
        void Execute();
    }
}
