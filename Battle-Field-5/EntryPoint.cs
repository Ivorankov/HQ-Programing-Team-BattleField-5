namespace MineFieldApp
{
    using MineFieldApp.Renderer;
    
    public static class EntryPoint
    {
        public static void Main()
        {
            IInputProvider inputProvider = new ConsoleInputProvider();
            IRenderer renderer = new ConsoleRender();
            Engine engine = new Engine(inputProvider, renderer);
            engine.Start();
        }
    }
}
