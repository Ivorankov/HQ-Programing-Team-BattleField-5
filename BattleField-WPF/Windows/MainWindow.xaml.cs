namespace BattleField_WPF
{
    using System;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnNewGameButtonClick(object sender, RoutedEventArgs e)
        {
            var gameWindow = new GameInitWindow();
            gameWindow.Show();
            this.Close();
        }

        private void OnShowHighScoresButtonClick(object sender, RoutedEventArgs e)
        {
            var highScoreWindow = new HighscoreWindow();
            highScoreWindow.Show();
        }

        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
