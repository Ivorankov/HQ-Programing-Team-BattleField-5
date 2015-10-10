namespace BattleField_WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Media;
    using MineFieldApp;
    using MineFieldApp.Engines;
    using MineFieldApp.Cells;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private IEngine engine;

        private const string PathToSoundFile = "../../Sounds/Explosion.wav";

        public GameWindow(int fieldSize, bool isExplosionChained)
        {
            InitializeComponent();
            StartTheEngine(fieldSize, isExplosionChained);//Vromm vromm
        }

        public void StartTheEngine(int fieldSize, bool isExplosionChained)
        {
            ICellDamageHandler damageHandler;

            //TODO
            if (isExplosionChained)
            {
                damageHandler = new DefaultDamageHandler();
            }
            else
            {
                damageHandler = new DefaultDamageHandler();
            }

            var renderer = new WpfRenderer(this);
            var engine = new ProxyEngine(renderer, damageHandler);
            this.engine = engine;
            var field = new GameField(fieldSize);
            this.engine.Init(field);
        }
    }
}
