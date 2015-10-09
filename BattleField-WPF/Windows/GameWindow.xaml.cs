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

            if (isExplosionChained)
            {
                damageHandler = new ChainDamageHandler();
            }
            else
            {
                damageHandler = new DefaultCellDamageHandler();
            }

            var renderer = new WpfRenderer(this);
            var engine = new ProxyEngine(renderer, damageHandler);
            this.engine = engine;
            var field = new GameField(fieldSize);
            this.engine.Init(field);
        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = sender as CellButton;
            if (cell.Status == CellStatus.WithMine)
            {
                this.engine.UpdateField(cell.Position);

                this.PlaySound(PathToSoundFile);
            }
        }
        private void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }
    }
}
