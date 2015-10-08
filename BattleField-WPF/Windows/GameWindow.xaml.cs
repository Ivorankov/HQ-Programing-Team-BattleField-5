using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Media;
using MineFieldApp;
using MineFieldApp.Renderer;
using MineFieldApp.Cells;

namespace BattleField_WPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private IEngine engine;

        private int fieldSize;

        private bool isExplosionChained;

        public GameWindow(int fieldSize, bool isExplosionChained)
        {
            InitializeComponent();
            this.fieldSize = fieldSize;
            this.isExplosionChained = isExplosionChained;
            StartTheEngine();//Vromm vromm
        }

        public void StartTheEngine()
        {
            ICellDamageHandler damageHandler;

            if (this.isExplosionChained)
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
            var field = new GameField(this.fieldSize);
            this.engine.Init(field);

        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = sender as CellButton;
            if (cell.Status == CellStatus.WithMine)
            {
                //Publishes event that calls the UpdateField method in the engine
                this.engine.UpdateField(cell.Pos);

                this.PlaySound("../../Sounds/Explosion.wav");
            }
        }
        public void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }
    }
}
