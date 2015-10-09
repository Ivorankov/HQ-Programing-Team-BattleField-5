namespace BattleField_WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using MineFieldApp;
    using MineFieldApp.Data;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for EndScreenWindow.xaml
    /// </summary>
    public partial class EndScreenWindow : Window
    {
        private GameObjData data;

        public EndScreenWindow(GameObjData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void OnMenuClick(object sender, RoutedEventArgs e)
        {
            var menu = new MainWindow();
            menu.Show();
            this.Close();
        }

        private void OnQuitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HighscoreLogger.Instance.AddHighscore(UserNameTextBox.Text, this.data.MovesCount);
            this.Hide();

            var highscoreWindow = new HighscoreWindow();
            highscoreWindow.Show();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            HighscoreLogger highscore = HighscoreLogger.Instance;
            var highscores = highscore.Highscores;

            var grid = sender as DataGrid;
            grid.ItemsSource = highscores;
        }
    }
}
