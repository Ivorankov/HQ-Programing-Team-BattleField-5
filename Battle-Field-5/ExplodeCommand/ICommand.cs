namespace MineFieldApp.ExplodeCommand
{
    public interface ICommand
    {

        bool IsValid();
        void Execute();
    }
}
