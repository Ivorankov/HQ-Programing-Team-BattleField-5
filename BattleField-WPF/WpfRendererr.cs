using BattleField;
using BattleField.Enums;
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
    //This is rought and temp so don't go crazy! And don't copy/paste/rename it cuz it won't magically work

    class WpfRendererr : IRenderer
    {
        // This will go in the Data object probably
        private int fieldSize;
        // This field is garbage and will be removed
        private GameWindow window;
        //Temp field will be removed (Its here for test purposes)
        private GameField field;

        private Grid grid;

        public WpfRendererr(GameWindow win)
        {
            //TODO better way for adding the gird (currently it's with win.Content)
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

            this.field = field;

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



            Cell cell;
            for (int r = 0; r < this.fieldSize; r++)
            {

                for (int c = 0; c < this.fieldSize; c++)
                {
                    if (field[r, c].Type == CellType.EMPTY)
                    {
                        cell = new Cell(r, c, status.normal);
                    }
                    else if (field[r, c].Type == CellType.BOMBED)
                    {
                        cell = new Cell(r, c, status.exploded);
                    }
                    else
                    {
                        cell = new Cell(r, c, status.withMine);
                    }


                    cell.Click += new RoutedEventHandler(Cell_Click);

                    grid.Children.Add(cell);
                    Grid.SetRow(cell, r);
                    Grid.SetColumn(cell, c);
                }
            }

            this.grid = grid;

            border.Child = grid;
            this.window.Content = border;
            this.SetCellRepresentation(this.grid);
        }

        public void ShowHighscores()
        {
            var highScoreWindow = new HighscoreWindow();
            highScoreWindow.Show();
        }

        public void ShowGameOver()
        {
            var gameOverWindow = new EndScreenWindow();
            gameOverWindow.Show();
        }

        public void Clear()//Refresh
        {
            this.SetCellRepresentation(this.grid);

        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = sender as Cell;
            MessageBox.Show("Hi, my position is: " + "Row: " + cell.Pos.X.ToString() + " Col:" + cell.Pos.Y.ToString() + " I will give these coordiates to the engine I promise :D");
            if (cell.Status == status.withMine)
            {
                MessageBox.Show("BOOM");
                this.field.ActivateMine(new Position(cell.Pos.X, cell.Pos.Y));

                this.Clear();
            }
            
        }
        private void SetCellRepresentation(Grid grid)
        {
            for (int row = 0; row < this.field.RowsCount; row++)
            {
                for (int col = 0; col < this.field.ColumnsCount; col++)
                {

                    UpdateCellStatus(grid, row, col, this.field[row, col].Type);
                }
            }
        }

        private void UpdateCellStatus(Grid grid, int row, int col, CellType type)
        {
            var cell = grid.Children
              .Cast<UIElement>()
              .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col) as Cell;

            if (type == CellType.EMPTY)
            { 

            }
            else if (type == CellType.BOMBED)
            {
                cell.Background = Brushes.Black;
            }
            else
            {
                cell.Background = Brushes.Red;
            }
        }
    }
}
