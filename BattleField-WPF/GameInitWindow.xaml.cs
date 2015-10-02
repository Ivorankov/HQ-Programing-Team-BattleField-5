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
    /// Interaction logic for GameInitWindow.xaml
    /// </summary>
    public partial class GameInitWindow : Window
    {
        public GameInitWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // I know it rly needs some validation xD
            var gameWindow = new GameWindow(int.Parse(this.ResponseTextBox.Text));
            this.Close();
            gameWindow.Show();
        }
    }
}
