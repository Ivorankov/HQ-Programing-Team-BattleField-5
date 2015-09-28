namespace MineFieldApp
{
    internal static class EntryPoint
    {
        internal static void Main()
        {
            //Engine.Start();

            var view = new ConsoleGameRenderer();
            var handler = new ConsoleUIHandler();
            var model = new Model();
            var test = new GameEngine(view, handler, model);

            test.StartGame();
        }
    }
}
