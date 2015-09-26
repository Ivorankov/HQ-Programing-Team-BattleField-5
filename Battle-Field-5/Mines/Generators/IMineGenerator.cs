namespace MineFieldApp.Mines.Generators
{
    public interface IMineGenerator
    {
        Mine Generate(Position position);
    }
}