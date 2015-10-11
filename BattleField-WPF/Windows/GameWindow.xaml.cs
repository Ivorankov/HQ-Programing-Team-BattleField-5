namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Windows;
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Engines;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private const string PathToSoundFile = "../../Sounds/Explosion.wav";

        private IEngine engine;

        public GameWindow(int fieldSize, bool isExplosionChained)
        {
            this.InitializeComponent();
            this.StartTheEngine(fieldSize, isExplosionChained);
        }

        public void StartTheEngine(int fieldSize, bool isExplosionChained)
        {
            ICellDamageHandler damageHandler = new DefaultDamageHandler();

            var renderer = new WpfRenderer(this);
            var engine = new ProxyEngine(renderer, damageHandler);
            this.engine = engine;
            var field = new GameField(fieldSize, isExplosionChained);
            this.engine.Init(field);
        }
    }
}
