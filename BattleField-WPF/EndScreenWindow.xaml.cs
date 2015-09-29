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
    /// Interaction logic for EndScreenWindow.xaml
    /// </summary>
    public partial class EndScreenWindow : Window
    {
        public EndScreenWindow()
        {
            InitializeComponent();
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
    }
}
