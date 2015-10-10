//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// /// Initializes a new instance of the <see cref="MainWindow" /> class
        /// Entry point of application
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes and opens <see cref="GameInitWindow"/> and closes MainWindow
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void OnNewGameButtonClick(object sender, RoutedEventArgs args)
        {
            var gameWindow = new GameInitWindow();
            gameWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Initializes and opens <see cref="HighscoreWindow"/>
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void OnShowHighScoresButtonClick(object sender, RoutedEventArgs args)
        {
            var highScoreWindow = new HighscoreWindow();
            highScoreWindow.Show();
            this.Hide();
        }

        /// <summary>
        /// Exits application
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void OnExitButtonClick(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }
    }
}
