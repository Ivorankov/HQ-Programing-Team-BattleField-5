using BattleField;
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

namespace BattleField_WPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Engine engine;
        private WpfInputProvider eventHandler;
        public GameWindow()
        {
            InitializeComponent();

            StartTheWindow();
            StartTheEngine();
        }

        public void StartTheEngine()
        {
            var gameField = new GameField(9);
            var test = new WpfRendererr(this);
            var engine = new Engine(test);
            var eventHandler = new WpfInputProvider(engine);
            this.eventHandler = eventHandler;
            this.eventHandler.position += this.eventHandler.GetPosition;
            this.engine = engine;
            engine.Start();
            
        }

        public void StartTheWindow()
        {
            InitializeComponent();
        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = sender as Cell;
            if (cell.Status == status.withMine)
            {
                this.eventHandler.Trigger(sender, e);
                this.PlaySound(@"C:\Users\kjkjh\Documents\GitHub\HQ-Programing-Team-BattleField-5\BattleField-WPF\Sounds\Explosion.wav");
            }
        }
        public void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }
    }
}
