namespace MineFieldApp.Renderer
{
    using MineFieldApp.Cells;
    using MineFieldApp.Cells.Mines;
    using MineFieldApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConsoleRender : IRenderer
    {
        private GameField field;

        public void ShowErrorMessage(String message)
        {
            Console.WriteLine(message);
        }

        public void ShowGameField(GameField field)
        {
            this.field = field;// Todo: find a better solution for this

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
            if (cell.Status == CellStatus.Destroyed)
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

        public void RefreshGameField()
        {
           Console.Clear();
           this.ShowGameField(this.field);
        }

        public void ShowHighscores(GameObjData data)
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
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void ShowGameOver(GameObjData data)
        {
            Console.WriteLine("Concratularions you finished the game!");
        }

    }
}
