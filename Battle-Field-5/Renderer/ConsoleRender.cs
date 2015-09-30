namespace MineFieldApp.Renderer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using MineFieldApp.Cells;
    using MineFieldApp.Cells.Mines;

    public class ConsoleRender : IRenderer
    {
        public void SayWelcome()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
        }

        public void ShowErrorMessage(String message)
        {
            Console.WriteLine(message);
        }

        public void ShowGameField(GameField field)
        {
            int rowsCount = field.RowsCount;
            int columnsCount = field.ColumnsCount;
            Console.WriteLine("   {0}", String.Join(" ", Enumerable.Range(0, columnsCount)));
            Console.WriteLine("   {0}", new String('-', rowsCount * 2));
            for (int i = 0; i < rowsCount; i++)
            {
                Console.WriteLine("{0} |{1}", i, String.Join(" ", Enumerable.Range(0, columnsCount).Select(column => this.GetCellRepresentation(field[i, column]))));
            }
        }

        private String GetCellRepresentation(Cell cell)
        {
            if (cell.Status == CellStatus.Destoryed)
            {
                return "X";
            }
            else if (cell is TinyMine)
            {
                return "1";
            }
            else if (cell is SmallMine)
            {
                return "2";
            }
            else if (cell is MediumMine)
            {
                return "3";
            }
            else if (cell is BigMine)
            {
                return "4";
            }
            else if (cell is GiantMine)
            {
                return "5";
            }
            else
            {
                return "-";
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowHighscores()
        {
            IList<Score> highscores = HighscoreLogger.Instance.Highscores;
            int totalWidth = 50;
            string highscoreTitle = "Highscores";
            int countOfashesOnTheLeft = (totalWidth - highscoreTitle.Length) / 2;
            Console.WriteLine("{0}{1}{2}", new String('-', countOfashesOnTheLeft), highscores, new String('-', totalWidth - highscoreTitle.Length - countOfashesOnTheLeft));
            Console.WriteLine("{0,8}{1,14}{2,13}", "Name", "Points", "Date");

            for (int i = 0; i < highscores.Count; i++)
            {
                Score currentScore = highscores[i];
                Console.WriteLine("{0,3}.{1,-10}-{2,4}    {3}", i + 1, currentScore.PlayerName, currentScore.Points, currentScore.Date);
            }

            Console.WriteLine(new String('-', totalWidth));
        }

        public void ShowGameOver()
        {
            Console.WriteLine("Concratularions you finished the game!");
        }
    }
}
