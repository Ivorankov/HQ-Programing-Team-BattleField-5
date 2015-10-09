namespace BattleField_WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using MineFieldApp;

    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        public HighscoreWindow()
        {

            InitializeComponent();

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            HighscoreLogger highscore = HighscoreLogger.Instance;
            var highscores = highscore.Highscores;

            var grid = sender as DataGrid;
            grid.ItemsSource = highscores;

        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
