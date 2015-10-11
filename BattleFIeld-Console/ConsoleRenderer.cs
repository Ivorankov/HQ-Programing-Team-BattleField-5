//-----------------------------------------------------------------------
// <copyright file="ConsoleRenderer.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains ConsoleRenderer class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cells;
    using Cells.Mines;
    using Data;

    /// <summary>
    /// A class representing a console renderer for showing data on the console.
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        private const int WallsCount = 2;

        private const char HorizontalWallSymbol = '-';

        private const char VerticalWallSymbol = '|';

        private const string AnyKeyMessage = "Press any key to continuue...";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleRenderer" /> class.
        /// </summary>
        public ConsoleRenderer()
        {
            this.LastCursorLeft = 1;
            this.LastCursorTop = 1;

            this.IsGameOver = false;

            Console.Title = "MineField";
            Console.CursorSize = 100;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            this.SetUpDefaultWindow();
        }

        /// <summary>
        /// An event for getting a position.
        /// </summary>
        public event EventHandler<PositionEventArgs> InputPosition;

        private int LastCursorLeft { get; set; }

        private int LastCursorTop { get; set; }

        private ConsoleWindowStatus WindowStatus { get; set; }

        private bool IsGameOver { get; set; }

        /// <summary>
        /// Show game field.
        /// </summary>
        /// <param name="field">The game field.</param>
        public void ShowGameField(GameField field)
        {
            if (this.WindowStatus != ConsoleWindowStatus.InGame)
            {
                this.SetUpInGameWindow(field);
            }

            int horizontalWallSize = Console.WindowWidth - ConsoleRenderer.WallsCount;
            string horizontalWall = new string(ConsoleRenderer.HorizontalWallSymbol, horizontalWallSize);

            string upperWall = string.Format(" {0} ", horizontalWall);
            string verticalWall = string.Format("{0}{1}{0}", ConsoleRenderer.VerticalWallSymbol, new string(' ', horizontalWallSize));
            string lowerWall = ' ' + horizontalWall;

            StringBuilder builder = new StringBuilder(upperWall);
            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                builder.Append(verticalWall);
            }

            builder.Append(lowerWall);

            Console.Write(builder);
            //// Console.ReadLine();
            this.RefreshGameField(field);
            this.SelectPosition();
        }

        /// <summary>
        /// Refreshes game field.
        /// </summary>
        /// <param name="field">The game field.</param>
        public void RefreshGameField(GameField field)
        {
            for (int row = 0; row < field.RowsCount; row++)
            {
                for (int col = 0; col < field.ColumnsCount; col++)
                {
                    ConsoleColor cellColor = this.GetCellColor(field[row, col]);

                    char cellSymbol = this.GetCellSymbol(field[row, col]);

                    this.SetWindowPosition(new Position(row, col));

                    Console.ForegroundColor = cellColor;
                    Console.Write(cellSymbol);
                }
            }

            Console.SetCursorPosition(this.LastCursorLeft, this.LastCursorTop);

        }

        /// <summary>
        /// Shows high scores.
        /// </summary>
        public void ShowHighscores()
        {
            Console.WriteLine("-----------------Highscores-----------------");
            IList<Score> highscores = HighscoreLogger.Instance.Highscores;
            int totalWidth = 50;
            string highscoreTitle = "Highscores";
            int countOfashesOnTheLeft = (totalWidth - highscoreTitle.Length) / 2;
            Console.WriteLine("{0,8}{1,14}{2,13}", "Name", "Points", "Date");

            for (int i = 0; i < highscores.Count; i++)
            {
                Score currentScore = highscores[i];

                Console.WriteLine("{0,3}.{1,-10}-{2,4}    {3}", i + 1, currentScore.PlayerName, currentScore.Points, currentScore.Date);
            }

            Console.WriteLine(new string('-', totalWidth));
        }

        /// <summary>
        /// Shows game over screen.
        /// </summary>
        /// <param name="data">Current game data.</param>
        public void ShowGameOver(GameData data)
        {
            Console.CursorVisible = false;
            Console.Clear();

            const int MessageCount = 2;
            Console.SetCursorPosition(0, (Console.WindowHeight / 2) - MessageCount);

            const string GameOverMessage = "Game Over.";
            string paddedGameOver = GameOverMessage.PadLeft((Console.WindowWidth / 2) + (GameOverMessage.Length / 2), ' ');
            Console.WriteLine(paddedGameOver);

            string movesMessage = string.Format("Moves: {0}", data.MovesCount);
            string paddedMovesMessage = movesMessage.PadLeft((Console.WindowWidth / 2) + (movesMessage.Length / 2), ' ');
            Console.WriteLine(paddedMovesMessage);

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.Enter);

            this.IsGameOver = true;
        }

        /// <summary>
        /// Shows an error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void ShowErrorMessage(string message)
        {
            //Console.WriteLine(message);
            Console.Beep();
        }

        /// <summary>
        /// Shows welcome screen.
        /// </summary>
        public void ShowWelcome()
        {
            const string title = "MineField";
            Console.WriteLine(@"Welcome to 'Battle filed' game!");
        }

        /// <summary>
        /// Fires input position event.
        /// </summary>
        /// <param name="args">Arguments of the position event.</param>
        protected virtual void OnInputPosition(PositionEventArgs args)
        {
            if (this.InputPosition != null)
            {
                this.InputPosition(this, args);
            }
        }

        private void SetUpInGameWindow(GameField field)
        {
            Console.Clear();
            int whiteSpaceCount = field.ColumnsCount - 1;

            int consoleRowsCount = field.RowsCount + ConsoleRenderer.WallsCount;
            int consoleColumnsCount = field.ColumnsCount + whiteSpaceCount + ConsoleRenderer.WallsCount;

            Console.SetWindowSize(consoleColumnsCount, consoleRowsCount);
            Console.SetBufferSize(consoleColumnsCount, consoleRowsCount);

            this.WindowStatus = ConsoleWindowStatus.InGame;
        }

        private void SetUpDefaultWindow()
        {
            Console.Clear();
            Console.SetWindowSize(35, 10);
            Console.SetBufferSize(35, 10);

            this.WindowStatus = ConsoleWindowStatus.Default;
        }

        private void SetWindowPosition(Position fieldPosition)
        {
            Console.SetCursorPosition((fieldPosition.Col * 2) + 1, fieldPosition.Row + 1);
        }

        private Position GetFieldPosition()
        {
            return new Position(Console.CursorTop - 1, (Console.CursorLeft - 1) / 2);
        }

        private char GetCellSymbol(Cell cell)
        {
            if (cell.IsDestroyed)
            {
                return 'X';
            }
            else if (cell is TinyMine)
            {
                return '1';
            }
            else if (cell is SmallMine)
            {
                return '2';
            }
            else if (cell is MediumMine)
            {
                return '3';
            }
            else if (cell is BigMine)
            {
                return '4';
            }
            else if (cell is GiantMine)
            {
                return '5';
            }
            else if (cell is EmptyCell)
            {
                return '-';
            }

            throw new NotImplementedException("Unknown Cell Type.");
        }

        private ConsoleColor GetCellColor(Cell cell)
        {
            if (cell.IsDestroyed)
            {
                return ConsoleColor.Gray;
            }
            else if (cell is TinyMine)
            {
                return ConsoleColor.Cyan;
            }
            else if (cell is SmallMine)
            {
                return ConsoleColor.Blue;
            }
            else if (cell is MediumMine)
            {
                return ConsoleColor.Yellow;
            }
            else if (cell is BigMine)
            {
                return ConsoleColor.Magenta;
            }
            else if (cell is GiantMine)
            {
                return ConsoleColor.Red;
            }
            else if (cell is EmptyCell)
            {
                return ConsoleColor.Black;
            }

            throw new NotImplementedException("Unknown Cell Type.");
        }

        private void SelectPosition()
        {
            while (true)
            {
                if (this.IsGameOver == true)
                {
                    return;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.DownArrow))
                {
                    int modifier = 1;
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        modifier *= -1;
                    }

                    int newTop = Console.CursorTop + modifier;

                    if ((0 < newTop) && (newTop < Console.WindowHeight - 1))
                    {
                        Console.CursorTop = newTop;
                    }
                }
                else if ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.RightArrow))
                {
                    int modifier = 2;
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        modifier *= -1;
                    }

                    int newLeft = Console.CursorLeft + modifier;
                    if ((0 < newLeft) && (newLeft < Console.WindowWidth - 1))
                    {
                        Console.CursorLeft = newLeft;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    this.LastCursorLeft = Console.CursorLeft;
                    this.LastCursorTop = Console.CursorTop;

                    Position pos = this.GetFieldPosition();
                    this.OnInputPosition(new PositionEventArgs(pos));
                }
            }
        }
    }
}
