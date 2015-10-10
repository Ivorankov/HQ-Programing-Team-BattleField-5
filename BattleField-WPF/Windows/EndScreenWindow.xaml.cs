//-----------------------------------------------------------------------
// <copyright file="EndScreenWindow.xaml.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using MineFieldApp;
    using MineFieldApp.Data;

    /// <summary>
    /// Interaction logic for EndScreenWindow.xaml
    /// </summary>
    public partial class EndScreenWindow : Window
    {
        /// <summary>
        /// Stores <see cref="GameData"/> object
        /// </summary>
        private GameData data;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndScreenWindow"/> class
        /// </summary>
        /// <param name="data">Used for values <see cref="GameData"/></param>
        public EndScreenWindow(GameData data)
        {
            this.InitializeComponent();
            this.data = data;
        }

        /// <summary>
        /// Initializes a <see cref="MainWindow"/> window and opens it.
        /// Closes <see cref="EndScreenWindow"/>
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void OnMenuClick(object sender, RoutedEventArgs args)
        {
            var menu = new MainWindow();
            menu.Show();
            this.Close();
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void OnQuitClick(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Gets an instance of <see cref="HighscoreLogger"/> class and adds a new entry
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void OnSaveButtonClick(object sender, RoutedEventArgs args)
        {
            HighscoreLogger.Instance.AddHighscore(UserNameTextBox.Text, this.data.MovesCount);
            this.Hide();

            var highscoreWindow = new HighscoreWindow();
            highscoreWindow.Show();
        }

        /// <summary>
        /// Gets an instance of <see cref="HighscoreLogger"/> class and populates DataGrid
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void DataGrid_Loaded(object sender, RoutedEventArgs args)
        {
            HighscoreLogger highscore = HighscoreLogger.Instance;
            var highscores = highscore.Highscores;

            var grid = sender as DataGrid;
            grid.ItemsSource = highscores;
        }
    }
}
