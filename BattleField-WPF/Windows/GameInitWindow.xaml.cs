//-----------------------------------------------------------------------
// <copyright file="GameInitWindow.xaml.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for GameInitWindow.xaml
    /// </summary>
    public partial class GameInitWindow : Window
    {
        /// <summary>
        /// Stores value that indicates if the radio button is pressed
        /// </summary>
        private bool isPressed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameInitWindow"/> class
        /// </summary>
        public GameInitWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Takes the value from the TextBox object, initializes <see cref="GameWindow"/> and opens it.
        /// Closes <see cref="GameInitWindow"/>
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void Button_Click(object sender, RoutedEventArgs args)
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

        /// <summary>
        /// Sets the value for isPressed variable
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
        private void RadioButton_Checked(object sender, RoutedEventArgs args)
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
