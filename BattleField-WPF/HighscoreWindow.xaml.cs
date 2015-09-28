using BattleField;
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
using System.Windows.Shapes;

namespace BattleField_WPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        public HighscoreWindow()
        {

            InitializeComponent();

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Highscore highscore = Highscore.Instance;
            var highscores = highscore.Highscores;

            var grid = sender as DataGrid;
            grid.ItemsSource = highscores;

        }
    }
}
