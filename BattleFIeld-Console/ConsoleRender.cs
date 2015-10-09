namespace MineFieldApp.Renderer
{
    using Cells;
    using Cells.Mines;
    using Data;
    using System;
    using System.Text;

    public class ConsoleRenderer : IRenderer
    {
        private const int WallsCount = 2;

        private const char HorizontalWallSymbol = '-';

        private const char VerticalWallSymbol = '|';

        public ConsoleRenderer()
        {
            this.LastCursorLeft = 1;
            this.LastCursorTop = 1;
        }

        private void SetUpWindow(GameField field)
        {
            Console.Title = "MineField";

            int whiteSpaceCount = field.ColumnsCount - 1;

            int consoleRowsCount = field.RowsCount + ConsoleRenderer.WallsCount;
            int consoleColumnsCount = field.ColumnsCount + whiteSpaceCount + ConsoleRenderer.WallsCount;

            Console.SetWindowSize(consoleColumnsCount, consoleRowsCount);
            Console.SetBufferSize(consoleColumnsCount, consoleRowsCount);
        }

        private void SetWindowPosition(Position fieldPosition)
        {
            Console.SetCursorPosition(((fieldPosition.Col * 2) + 1), fieldPosition.Row + 1);
        }

        private Position GetFieldPosition()
        {
            return new Position(Console.CursorTop - 1, (Console.CursorLeft - 1) / 2);
        }

        private char GetCellSymbol(Cell cell)
        {
            if (cell.Status == CellStatus.Destroyed)
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
            else if (cell is EmptyCell || cell is Cell)
            {
                return '-';
            }

            throw new NotImplementedException("Unknown Cell Type.");
        }

        public void ShowGameField(GameField field)
        {
            this.SetUpWindow(field);

            int horizontalWallSize = Console.WindowWidth - ConsoleRenderer.WallsCount;
            string horizontalWall = new string(ConsoleRenderer.HorizontalWallSymbol, horizontalWallSize);

            string upperWall = string.Format(" {0} ", horizontalWall);
            string verticalWall = string.Format("{0}{1}{0}", ConsoleRenderer.VerticalWallSymbol, new String(' ' , horizontalWallSize));
            string lowerWall = ' ' + horizontalWall; 

            StringBuilder builder = new StringBuilder(upperWall);
            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                builder.Append(verticalWall);
            }
            builder.Append(lowerWall);

            Console.Write(builder);
            //Console.ReadLine();
            this.RefreshGameField(field);
        }

        public void RefreshGameField(GameField field)
        {
            for (int row = 0; row < field.RowsCount; row++)
            {
                for (int col = 0; col < field.ColumnsCount; col++)
                {
                    char cellSymbol = this.GetCellSymbol(field[row, col]);

                    this.SetWindowPosition(new Position(row, col));

                    Console.Write(cellSymbol);
                }
            }

            Console.SetCursorPosition(this.LastCursorLeft, this.LastCursorTop);
        }

        public Position SelectPosition()
        {
            while (true)
            {
                if (!Console.KeyAvailable)
                {
                    continue;
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

                    return this.GetFieldPosition();
                }
            }
        }

        public void ShowHighscores(GameData data)
        {
            Console.Clear();
            Console.WriteLine("How does one get scores from GameObjData?");
        }

        public void ShowGameOver(GameData data)
        {
            Console.CursorVisible = false;
            Console.Clear();

            const int MessageCount = 2;
            Console.SetCursorPosition(0, (Console.WindowHeight / 2) - MessageCount);

            const string GameOverMessage = "Game Over.";
            string paddedGameOver = GameOverMessage.PadLeft((Console.WindowWidth / 2) +  (GameOverMessage.Length / 2), ' ');
            Console.WriteLine(paddedGameOver);

            string movesMessage = string.Format("Moves: {0}", data.MovesCount);
            string paddedMovesMessage = movesMessage.PadLeft((Console.WindowWidth / 2) + (movesMessage.Length / 2), ' ');
            Console.WriteLine(paddedMovesMessage);

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Enter);
        }

        public void ShowErrorMessage(string message)
        {
        }

        private int LastCursorLeft { get; set; }

        private int LastCursorTop { get; set; }
    }
}
