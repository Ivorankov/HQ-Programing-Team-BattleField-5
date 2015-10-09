namespace BattleField_WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Resources;
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

        public event EventHandler<PositionEventArg> InputPosition;

        public WpfRenderer(GameWindow win)
        {
            this.window = win;
            this.window.MouseDown += this.HandleMouseDown;
            var brush = CreateBrush(FilePathToImages + "Background.gif");
            this.window.Background = brush;
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
            this.SetCellRepresentation(this.grid, field);
        }

        public void ShowHighscores(GameData data)
        {

        }

        public void ShowGameOver(GameData data)
        {
            var gameOverWindow = new EndScreenWindow(data);
            gameOverWindow.Show();
            this.window.Hide();
        }

        public void RefreshGameField(GameField field)
        {
            this.SetCellRepresentation(this.grid, field);
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
        private void SetCellRepresentation(Grid grid, GameField field)
        {
            for (int row = 0; row < field.RowsCount; row++)
            {
                for (int col = 0; col < field.ColumnsCount; col++)
                {
                    UpdateCellStatus(grid, row, col, field[row, col].IsDestroyed, field);
                }
            }
        }
        //Sets background image on selected cell element
        private void UpdateCellStatus(Grid grid, int row, int col, bool isCellDestroyed, GameField field)
        {
            var cell = grid.Children
              .Cast<UIElement>()
              .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col) as CellButton;

            if (isCellDestroyed)
            {
                cell.Background = this.CreateBrush(FilePathToImages + "ExplodedDirt.png");
            }
            else 
            {
                if (field[row, col] is Mine)
                {
                    cell.Background = GetMineRepresentaion(field[row, col]);
                }
                else
                {
                    cell.Background = this.CreateBrush(FilePathToImages + "Dirt.jpg");
                }
            }
        }
        //Sets mine image depending on the type (size)
        private Brush GetMineRepresentaion(Cell cell)
        {
            var brush = new ImageBrush();

            if (cell is TinyMine)
            {
                brush = this.CreateBrush(FilePathToImages + "Mine1.png");
            }
            else if (cell is SmallMine)
            {
                brush = this.CreateBrush(FilePathToImages + "Mine2.png");
            }
            else if (cell is MediumMine)
            {
                brush = this.CreateBrush(FilePathToImages + "Mine3.png");
            }
            else if (cell is BigMine)
            {
                brush = this.CreateBrush(FilePathToImages + "Mine4.png");
            }
            else if (cell is GiantMine)
            {
                brush = this.CreateBrush(FilePathToImages + "Mine5.png");
            }

            return brush;
        }
        //Used to create brush object (the thing that draws the img to the background)
        private ImageBrush CreateBrush(string filePath)
        {
            Uri uriPathToImg = new Uri(filePath, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(uriPathToImg);
            BitmapFrame imageData = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = imageData;

            return brush;
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
                    if (field[r, c].IsDestroyed)
                    {
                        cell = new CellButton(r, c, CellStatus.Destroyed);
                    }
                    else
                    {
                        if (field[r, c] is Mine)
                        {
                            cell = new CellButton(r, c, CellStatus.WithMine);
                        }
                        else
                        {
                            cell = new CellButton(r, c, CellStatus.Normal);
                        }
                    }

                    cell.Click += new RoutedEventHandler(this.HandleMouseDown);

                    grid.Children.Add(cell);
                    Grid.SetRow(cell, r);
                    Grid.SetColumn(cell, c);
                }
            }

            return grid;
        }

        private void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }
    }
}
