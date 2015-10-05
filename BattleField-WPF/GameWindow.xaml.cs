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

        public GameWindow(int fieldSize)
        {
            InitializeComponent();
            var renderer = new WpfRenderer(this);
            this.engine = new Engine(renderer);
            this.engine.Start(fieldSize);
        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = sender as Cell;
            if (cell.Status == status.withMine)
            {
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
