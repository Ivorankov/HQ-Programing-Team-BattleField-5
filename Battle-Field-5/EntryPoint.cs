namespace BattleField
{
    using BattleField.Renderer;

    public static class EntryPoint
    {
        public static void Main()
        {
            ConsoleInputProvider inputProvider = new ConsoleInputProvider();
            ConsoleRender renderer = new ConsoleRender();
            Engine engine = new Engine(inputProvider, renderer);
            engine.Start();
        }
    }
}
