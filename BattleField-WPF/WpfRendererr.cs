using BattleField;
using BattleField.Enums;
using BattleField.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

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
        public void SayWelcome()// I will say goodbye to this stupid method soon 
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)// Maybe this will be removed
        {
            throw new NotImplementedException();
        }

        public void ShowGameField(BattleField.GameField field)
        {
            this.field = field;
            this.fieldSize = field.RowsCount;

            Border border = new Border();
            border.BorderThickness = new Thickness(10);
            border.BorderBrush = Brushes.LightGreen;

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

            if (cell.Status == status.withMine)
            {
                this.field.ActivateMine(cell.Pos);
                this.Clear();
                this.PlaySound(@"C:\Users\kjkjh\Documents\GitHub\HQ-Programing-Team-BattleField-5\BattleField-WPF\Sounds\Explosion.wav");
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
                cell.Background = this.CreateBrush("Images/Dirt.jpg");
            }
            else if (type == CellType.BOMBED)
            {
                cell.Background = this.CreateBrush("Images/ExplodedDirt.png");
            }
            else
            {
                cell.Background = GetMineRepresentaion(type);
            }
        }

        private Brush GetMineRepresentaion(CellType type)
        {
            var brush = new ImageBrush();

            if (type == CellType.TINYMINE)
            {
                brush = this.CreateBrush("Images/Mine1.png");
            }
            else if (type == CellType.SMALLMINE)
            {
                brush = this.CreateBrush("Images/Mine2.png");
            }
            else if (type == CellType.BIGMINE)
            {
                brush = this.CreateBrush("Images/Mine3.png");
            }
            else if (type == CellType.HUGEMINE)
            {
                brush = this.CreateBrush("Images/Mine4.png");
            }
            else if (type == CellType.GIANTMINE)
            {
                brush = this.CreateBrush("Images/Mine5.png");
            }

            return brush;
        }

        private void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }

        private ImageBrush CreateBrush(string filePath)
        {
            Uri uriPathToImg = new Uri(filePath, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(uriPathToImg);
            BitmapFrame imageData = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = imageData;

            return brush;
        }
    }
}
