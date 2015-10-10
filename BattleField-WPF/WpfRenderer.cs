//-----------------------------------------------------------------------
// <copyright file="WpfRenderer.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Media;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Cells.Mines;
    using MineFieldApp.Data;
    using MineFieldApp.Renderer;

    /// <summary>
    /// Class that implements interface IRenderer and provides a way for the engine to interact with the window components
    /// </summary>
    public class WpfRenderer : IRenderer
    {
        /// <summary>
        /// Stores the file path to the image
        /// </summary>
        private const string FilePathToImages = "../Images/";

        /// <summary>
        /// Stores the file path to the sound
        /// </summary>
        private const string PathToSoundFile = "../../Sounds/";

        /// <summary>
        /// Stores value for max grid width 
        /// </summary>
        private const int GridWidth = 900;

        /// <summary>
        /// Stores value for max grid height
        /// </summary>
        private const int GridHeight = 900;

        /// <summary>
        /// Stores the window object
        /// </summary>
        private GameWindow window;

        /// <summary>
        /// Stores the gird element
        /// </summary>
        private Grid grid;

        /// <summary>
        /// Stores the brush object
        /// </summary>
        private IItem brush; // Temp or maybe not depends on how it ends up looking when its complete

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfRenderer" /> class
        /// </summary>
        /// <param name="win">GameWindow object that will be populated</param>
        public WpfRenderer(GameWindow win)
        {
            this.window = win;
            this.window.MouseDown += this.HandleMouseDown;

            BrushFactory factory = new BrushFactory();
            factory.Save(0, new CellBrush());
            this.brush = factory.Get(0);
        }

        /// <summary>
        /// Subscribes to MouseDown event from window and passes to engine
        /// </summary>
        public event EventHandler<PositionEventArg> InputPosition;

        /// <summary>
        /// Shows error messages
        /// </summary>
        /// <param name="message">Contains error message</param>
        public void ShowErrorMessage(string message)
        {
        }

        /// <summary>
        /// Initializes grid element and appends it to the window
        /// </summary>
        /// <param name="field">Object containing the information about the cell content</param>
        public void ShowGameField(GameField field)
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(10);
            border.BorderBrush = Brushes.White;

            this.grid = this.CreateGridElement(field, GridWidth, GridHeight);
            border.Child = this.grid;
            this.window.Content = border;
        }

        /// <summary>
        /// Does not show the high score
        /// </summary>
        public void ShowHighscores()
        {
            // Do not throw not implimented exeptions principle? xD TODO Refactor the engine to not use this, it will be shown by gameover in console?
        }

        /// <summary>
        /// Initializes and opens EndScreenWindow. Closes GameWindow
        /// </summary>
        /// <param name="data">Object containing player score</param>
        public void ShowGameOver(GameData data)
        {
            var gameOverWindow = new EndScreenWindow(data);
            gameOverWindow.Show();
            this.window.Hide();
        }

        /// <summary>
        /// Updates the UI grid component
        /// </summary>
        /// <param name="field">Object containing the information about the cell content</param>
        public void RefreshGameField(GameField field)
        {
            this.UpdateField(this.grid, field);
        }

        /// <summary>
        /// Does jack shit
        /// </summary>
        public void ShowWelcome()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publishes event
        /// </summary>
        /// <param name="args">Object containing Position of clicked cell</param>
        protected virtual void OnInputPosition(PositionEventArg args)
        {
            if (this.InputPosition != null)
            {
                this.InputPosition(this, args);
            }
        }

        /// <summary>
        /// Executed on MouseDown event
        /// </summary>
        /// <param name="sender">Object containing information about sender object</param>
        /// <param name="args">Object containing arguments</param>
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
            //// Else play some other sound ? 
        }

        /// <summary>
        /// Updates the background images of the <see cref="CellButton" /> in the grid
        /// </summary>
        /// <param name="grid">Object containing instances of <see cref="CellButton" /></param>
        /// <param name="field">Object containing information about the cell content</param>
        private void UpdateField(Grid grid, GameField field)
        {
            for (int row = 0; row < field.RowsCount; row++)
            {
                for (int col = 0; col < field.ColumnsCount; col++)
                {
                    this.UpdateCellStatus(grid, row, col, field[row, col].IsDestroyed);
                }
            }
        }

        /// <summary>
        /// Updates the background images of a specified <see cref="CellButton" />
        /// </summary>
        /// <param name="grid">Object containing instances of <see cref="CellButton" /></param>
        /// <param name="row">Value that indicates the row of the gird element</param>
        /// <param name="col">Value that indicates the col of the grid element</param>
        /// <param name="isCellDestroyed">Value that indicates if the cell background should be changed</param>
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

        /// <summary>
        /// Initializes grid element and populates it with <see cref="CellButton" />
        /// </summary>
        /// <param name="field">Object containing the information about the cell content</param>
        /// <param name="gridWidth">Value that specifies the max width of the grid element</param>
        /// <param name="gridHeigth">Value that specifies the max height of the grid element</param>
        /// <returns>Window grid element</returns>
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
            for (int row = 0; row < fieldRowCount; row++)
            {
                for (int col = 0; col < fieldColCount; col++)
                {
                    if (field[row, col] is Mine)
                    {
                        cell = new CellButton(row, col, CellStatus.WithMine);
                        var mineType = this.GetMineRepresentaion(field[row, col]);
                        cell.Background = this.brush.GetBrush(mineType);
                    }
                    else
                    {
                        cell = new CellButton(row, col, CellStatus.Normal);
                        cell.Background = this.brush.GetBrush(0);
                    }

                    cell.Click += new RoutedEventHandler(this.HandleMouseDown);
                    grid.Children.Add(cell);
                    Grid.SetRow(cell, row);
                    Grid.SetColumn(cell, col);
                }
            }

            return grid;
        }

        /// <summary>
        /// Used to determine Mine type
        /// </summary>
        /// <param name="cell">Cell element containing information about the type</param>
        /// <returns>Returns value used to indicate the mine type </returns>
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

        /// <summary>
        /// Plays sound
        /// </summary>
        /// <param name="pathToWavFile">Value containing path to the file</param>
        private void PlaySound(string pathToWavFile)
        {
            var sound = new SoundPlayer(pathToWavFile);
            sound.Play();
        }
    }
}
