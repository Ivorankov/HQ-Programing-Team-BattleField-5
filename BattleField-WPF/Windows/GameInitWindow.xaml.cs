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
        private bool isPressed = false;

        public GameInitWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fieldSizeInput = int.Parse(this.ResponseTextBox.Text);

            if (5 <= fieldSizeInput && fieldSizeInput <= 15)
            {
                var gameWindow = new GameWindow(fieldSizeInput, this.isPressed);
                this.Close();
                gameWindow.Show();
            }
            else
            {
                MessageBox.Show("Field size has to be (5-15)");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.isPressed)
            {
                this.isPressed = false;
            }
            else
            {
                this.isPressed = true;
            }
        }
    }
}
