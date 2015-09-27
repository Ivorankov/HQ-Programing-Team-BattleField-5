namespace MineFieldApp
{
    internal static class EntryPoint
    {
        internal static void Main()
        {
            //Engine.Start();

            var view = new ConsoleGameRenderer();
            var handler = new ConsoleUIHandler();
            var test = new GameEngine(view, handler);

            test.StartGame();
        }
    }
}
