using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using MineFieldApp;
using MineFieldApp.Renderer;
using MineFieldApp.Cells;
using MineFieldApp.Data;
using MineFieldApp.Cells.Mines;

namespace BattleField_WPF
{
    //Under construction

    class WpfRenderer : IRenderer
    {
        private const string FILEPATH = "../Images/";
        // This will go in the Data object probably
        private int fieldSize;
        // This field is garbage and will be removed
        private GameWindow window;
        //Temp field will be removed (Its here for test purposes)
        private GameField field;

        private Grid grid;

        public WpfRenderer(GameWindow win)
        {
            //TODO better way for adding the gird (currently it's with win.Content)
            this.window = win;
        }

        public void ShowErrorMessage(string message)// Maybe this will be removed
        {

        }
        //Creates all the elements and appends them to the window
        public void ShowGameField(GameField field)
        {
            this.field = field;
            this.fieldSize = field.RowsCount;

            Border border = new Border();
            border.BorderThickness = new Thickness(10);
            border.BorderBrush = Brushes.LightGreen;

            this.grid = CreateGridElement();
            border.Child = grid;
            this.window.Content = border;
            this.SetCellRepresentation(this.grid);
        }

        public void ShowHighscores(GameObjData data)
        {
            var highScoreWindow = new HighscoreWindow();
            highScoreWindow.Show();
        }

        public void ShowGameOver(GameObjData data)
        {
            var gameOverWindow = new EndScreenWindow(data);
            gameOverWindow.Show();
            this.window.Hide();
        }

        public void RefreshGameField(GameField field)
        {
            this.SetCellRepresentation(this.grid);
        }

        //Sets the background img on all the cells
        private void SetCellRepresentation(Grid grid)
        {
            for (int row = 0; row < this.field.RowsCount; row++)
            {
                for (int col = 0; col < this.field.ColumnsCount; col++)
                {
                    UpdateCellStatus(grid, row, col, this.field[row, col].Status);
                }
            }
        }
        //Sets background image on selected cell element
        private void UpdateCellStatus(Grid grid, int row, int col, CellStatus status)
        {
            var cell = grid.Children
              .Cast<UIElement>()
              .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col) as CellButton;

            if (status == CellStatus.Normal)
            {
                if (this.field[row, col] is Mine)
                {
                    cell.Background = GetMineRepresentaion(this.field[row, col]);
                }
                else
                {
                    cell.Background = this.CreateBrush(FILEPATH + "Dirt.jpg");
                }
            }
            else if (status == CellStatus.Destroyed)
            {
                cell.Background = this.CreateBrush(FILEPATH + "ExplodedDirt.png");
            }

        }
        //Sets mine image depending on the type (size)
        private Brush GetMineRepresentaion(Cell cell)
        {
            var brush = new ImageBrush();

            if (cell is TinyMine)
            {
                brush = this.CreateBrush(FILEPATH + "Mine1.png");
            }
            else if (cell is SmallMine)
            {
                brush = this.CreateBrush(FILEPATH + "Mine2.png");
            }
            else if (cell is MediumMine)
            {
                brush = this.CreateBrush(FILEPATH + "Mine3.png");
            }
            else if (cell is BigMine)
            {
                brush = this.CreateBrush(FILEPATH + "Mine4.png");
            }
            else if (cell is GiantMine)
            {
                brush = this.CreateBrush(FILEPATH + "Mine5.png");
            }

            return brush;
        }
        //Used to create brush object (the thing that draws the img to the cell background)
        private ImageBrush CreateBrush(string filePath)
        {
            Uri uriPathToImg = new Uri(filePath, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(uriPathToImg);
            BitmapFrame imageData = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = imageData;

            return brush;
        }

        private Grid CreateGridElement()
        {

            var grid = new Grid();
            grid.MaxHeight = 900;
            grid.MaxWidth = 900;


            for (int i = 0; i < this.fieldSize; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                grid.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < this.fieldSize; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                grid.ColumnDefinitions.Add(coldef);
            }

            CellButton cell;
            for (int r = 0; r < this.fieldSize; r++)
            {
                for (int c = 0; c < this.fieldSize; c++)
                {
                    if (this.field[r, c].Status == CellStatus.Normal)
                    {
                        if (this.field[r, c] is Mine)
                        {
                            cell = new CellButton(r, c, CellStatus.WithMine);
                        }
                        else
                        {
                            cell = new CellButton(r, c, CellStatus.Normal);
                        }
                    }
                    else if (this.field[r, c].Status == CellStatus.Destroyed)
                    {
                        cell = new CellButton(r, c, CellStatus.Destroyed);
                    }
                    else
                    {
                        cell = new CellButton(r, c, CellStatus.Normal); // Temp way to make it work
                    }

                    cell.Click += new RoutedEventHandler(this.window.Cell_Click);

                    grid.Children.Add(cell);
                    Grid.SetRow(cell, r);
                    Grid.SetColumn(cell, c);
                }
            }

            return grid;
        }
    }
}
