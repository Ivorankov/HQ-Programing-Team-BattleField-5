namespace BattleField_WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Cells.Mines;
    using MineFieldApp.Data;
    using MineFieldApp.Renderer;
    using System.Media;
    //Under construction

    class WpfRenderer : IRenderer
    {
        private const string FilePathToImages = "../Images/";

        private const string PathToSoundFile = "../../Sounds/";

        private const int GridWidth = 900;

        private const int GridHeigth = 900;

        private GameWindow window;

        private Grid grid;

        private IItem brush; // Temp or maybe not depends on how it ends up looking when its complete

        public event EventHandler<PositionEventArg> InputPosition;

        public WpfRenderer(GameWindow win)
        {
            this.window = win;
            this.window.MouseDown += this.HandleMouseDown;

            BrushFactory factory = new BrushFactory();// Temp probably find a better place for it soon
            factory.Save(0, new CellBrush());
            this.brush = factory.Get(0);
        }

        public void ShowErrorMessage(string message)// Maybe this will be removed
        {

        }
        //Creates all the elements and appends them to the window
        public void ShowGameField(GameField field)
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(10);
            border.BorderBrush = Brushes.White;

            this.grid = CreateGridElement(field, GridWidth, GridHeigth);
            border.Child = grid;
            this.window.Content = border;
        }

        public void ShowHighscores(GameData data)
        {
            //Do not throw not implimented exeptions principle? xD TODO Refactor the engine to not use this, it will be shown by gameover in console?
        }

        public void ShowGameOver(GameData data)
        {
            var gameOverWindow = new EndScreenWindow(data);
            gameOverWindow.Show();
            this.window.Hide();
        }

        public void RefreshGameField(GameField field)
        {
            this.UpdateField(this.grid, field);
        }

        protected virtual void OnInputPosition(PositionEventArg args)
        {
            if (this.InputPosition != null)
            {
                this.InputPosition(this, args);
            }
        }

        private void HandleMouseDown(object sender, EventArgs args)
        {
            var cell = sender as CellButton;
            if (cell != null)
            {
                if (cell.Status == CellStatus.WithMine)
                {
                    this.OnInputPosition(new PositionEventArg(cell.Position));
                    this.PlaySound(PathToSoundFile + "Explosion.wav");
                }
            }
            //Else play some other sound ? 
        }

        //Sets the background img on all the cells
        private void UpdateField(Grid grid, GameField field)
        {
            for (int row = 0; row < field.RowsCount; row++)
            {
                for (int col = 0; col < field.ColumnsCount; col++)
                {
                    UpdateCellStatus(grid, row, col, field[row, col].IsDestroyed);
                }
            }
        }
        //Sets background image on selected cell element
        private void UpdateCellStatus(Grid grid, int row, int col, bool isCellDestroyed)
        {
            var cell = grid.Children
              .Cast<UIElement>()
              .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col) as CellButton;

            if (isCellDestroyed)
            {
                cell.Background = this.brush.GetBrush(1);
            }

        }

        private Grid CreateGridElement(GameField field, int gridWidth, int gridHeigth)
        {
            var fieldRowCount = field.RowsCount;
            var fieldColCount = field.ColumnsCount;
            var grid = new Grid();
            grid.MaxWidth = gridWidth;
            grid.MaxHeight = gridHeigth;


            for (int i = 0; i < fieldRowCount; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                grid.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < fieldColCount; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                grid.ColumnDefinitions.Add(coldef);
            }

            CellButton cell;
            for (int r = 0; r < fieldRowCount; r++)
            {
                for (int c = 0; c < fieldColCount; c++)
                {

                    if (field[r, c] is Mine)
                    {
                        cell = new CellButton(r, c, CellStatus.WithMine);
                        var mineType = GetMineRepresentaion(field[r, c]);
                        cell.Background = this.brush.GetBrush(mineType);
                    }
                    else
                    {
                        cell = new CellButton(r, c, CellStatus.Normal);
                        cell.Background = this.brush.GetBrush(0);
                    }


                    cell.Click += new RoutedEventHandler(this.HandleMouseDown);
                    grid.Children.Add(cell);
                    Grid.SetRow(cell, r);
                    Grid.SetColumn(cell, c);
                }
            }

            return grid;
        }

        //Sets mine image depending on the type (size)
        private int GetMineRepresentaion(Cell cell)
        {
            var brushType = 0;

            if (cell is TinyMine)
            {
                brushType = 2;
            }
            else if (cell is SmallMine)
            {
                brushType = 3;
            }
            else if (cell is MediumMine)
            {
                brushType = 4;
            }
            else if (cell is BigMine)
            {
                brushType = 5;
            }
            else if (cell is GiantMine)
            {
                brushType = 6;
            }

            return brushType;
        }

        private void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }
    }
}
