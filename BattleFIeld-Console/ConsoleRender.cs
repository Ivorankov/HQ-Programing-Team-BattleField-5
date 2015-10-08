namespace MineFieldApp.Renderer
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using MineFieldApp.Cells;
    using MineFieldApp.Cells.Mines;
    using MineFieldApp.Data;

    public class ConsoleRenderer : IRenderer
    {
        private const int WallsCount = 2;

        private const char HorizontalWallSymbol = '-';

        private void SetUpWindow(GameField field)
        {
            Console.Title = "MineField";

            int whiteSpaceCount = field.ColumnsCount - 1;

            int consoleRowsCount = field.RowsCount + ConsoleRenderer.WallsCount;
            int consoleColumnsCount = field.ColumnsCount + whiteSpaceCount + ConsoleRenderer.WallsCount;

            Console.SetWindowSize(consoleColumnsCount, consoleRowsCount);
            Console.SetBufferSize(consoleColumnsCount, consoleRowsCount);
        }

        private Position GetWindowPosition(Position fieldPosition)
        {
            return new Position(fieldPosition.Row + 1, fieldPosition.Col * 2);
        }

        public void ShowGameField(GameField field)
        {
            this.SetUpWindow(field);

            int horizontalWallSize = Console.WindowWidth - ConsoleRenderer.WallsCount;
            string horizontalWall = new string(ConsoleRenderer.HorizontalWallSymbol, horizontalWallSize);

            string upperWall = string.Format(" {0} ", horizontalWall);
            string verticalWall = string.Format("|{0}|", new String(' ' , horizontalWallSize));
            string lowerWall = ' ' + horizontalWall; 

            StringBuilder builder = new StringBuilder(upperWall);
            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                builder.Append(verticalWall);
            }
            builder.Append(lowerWall);

            Console.Write(builder);
            Console.ReadLine();
            //this.RefreshGameField(field);
        }

        public void RefreshGameField(GameField field)
        {
            throw new NotImplementedException();
        }

        public void ShowHighscores(GameObjData data)
        {
            throw new NotImplementedException();
        }

        public void ShowGameOver(GameObjData data)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
