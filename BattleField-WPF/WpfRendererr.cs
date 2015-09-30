using BattleField.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BattleField_WPF
{
    //This is rought and temp so don't go crazy!

    class WpfRendererr : IRenderer
    {
        private int fieldSize;
        private GameWindow window;
        public WpfRendererr(GameWindow win)
        {
            this.window = win;
        }
        public void SayWelcome()
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowGameField(BattleField.GameField field)
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(10);
            border.BorderBrush = Brushes.LightGreen;
            this.fieldSize = field.RowsCount;
            var grid = new Grid();

            grid.MaxHeight = 900;
            grid.MaxWidth = 900;


            for (int i = 0; i < this.fieldSize; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                //rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < this.fieldSize; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                //coldef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(coldef);
            }

            int idCount = 0;
            for (int r = 0; r < this.fieldSize; r++)
            {

                for (int c = 0; c < this.fieldSize; c++)
                {

                    Cell btn = new Cell(idCount);
                    btn.Click += new RoutedEventHandler(Cell_Click);
                    grid.Children.Add(btn);
                    Grid.SetRow(btn, r);
                    Grid.SetColumn(btn, c);
                    idCount++;
                }
            }

            border.Child = grid;
            this.window.Content = border;
        }

        public void ShowHighscores()
        {
            throw new NotImplementedException();
        }

        public void ShowGameOver()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = sender as Cell;
            MessageBox.Show("Hi, my id is: " + cell.Id.ToString());
        }
    }
}
