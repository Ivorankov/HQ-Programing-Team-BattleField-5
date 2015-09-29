using MineFieldApp;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleField_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void OnNewGameButtonClick(object sender, RoutedEventArgs e)
        {
            var gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void OnShowHighScoresButtonClick(object sender, RoutedEventArgs e)
        {
            var test = new HighscoreWindow();
            test.Show();
        }

        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
