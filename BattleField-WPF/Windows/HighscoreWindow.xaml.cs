//-----------------------------------------------------------------------
// <copyright file="HighscoreWindow.xaml.cs" company="BattleField-5 team">
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

    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreWindow" /> class
        /// </summary>
        public HighscoreWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes instance of <see cref="HighscoreLogger"/> and populates DataGrid object
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

        /// <summary>
        /// Initializes and opens <see cref="MainWindow"/> and closes <see cref="HighscoreWindow"/>
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void BackToMenu_Click(object sender, RoutedEventArgs args)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
