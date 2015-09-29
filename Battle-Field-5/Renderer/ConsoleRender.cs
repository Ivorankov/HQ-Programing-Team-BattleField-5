namespace MineFieldApp.Renderer
{
    using MineFieldApp.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            switch (cell.Type)
            {
                case CellType.EMPTY: return "-";
                case CellType.BOMBED: return "X";
                case CellType.GIANTMINE: return "5";
                case CellType.HUGEMINE: return "4";
                case CellType.BIGMINE: return "3";
                case CellType.SMALLMINE: return "2";
                case CellType.TINYMINE: return "1";
                default: throw new NotSupportedException();
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowHighscores()
        {
            IList<Score> highscores = Highscore.Instance.Highscores;
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
