namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;

    using RNGs;
    using Cells;
    using Cells.Mines.Factories;

    public class GameField
    {
        private const int MINIMUM_MINES_PERCENT = 15;

        private const int MAXIMUM_MINES_PERCENT = 30;

        //private Cell.CellFactory factory;

        private Cell[,] field;

        private int minesCount;

        public GameField(IRandomGenerator random, IMineFactory mineFactory, int size)
        {
            this.Random = random;
            this.MineFactory = mineFactory;

            this.field = new Cell[size, size];
            this.FillFieldWithEmptyCells();
            this.minesCount = this.CalculateInitialMinesCount();
            this.FillFieldMines();
        }

        public GameField(IRandomGenerator random, int size)
            : this(random, new RandomMineFactory(), size)
        {

        }

        public GameField(IMineFactory mineFactory, int size)
            : this(RandomGenerator.Instance, mineFactory, size)
        {

        }

        public GameField(int size)
        {

        }

        private IRandomGenerator Random { get; set; }

        private IMineFactory MineFactory { get; set; }

        public Cell this[int i, int j]
        {
            get
            {
                if (this.IsInRange(new Position(i, j)))
                {
                    return field[i, j];
                }

                throw new IndexOutOfRangeException();
            }
        }

        public int RowsCount
        {
            get
            {
                return this.field.GetLength(0);
            }
        }

        public int ColumnsCount
        {
            get
            {
                return this.field.GetLength(1);
            }
        }

        public bool IsInRange(Position position)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < this.RowsCount && position.Y < this.ColumnsCount;
        }

        public bool HasMinesLeft()
        {
            return minesCount > 0;
        }

        private void FillFieldWithEmptyCells()
        {
            for (int i = 0; i < this.RowsCount; i++)
            {
                for (int j = 0; j < this.ColumnsCount; j++)
                {
                    this.field[i, j] = this.factory.CreateEmptyCell(new Position(i, j));
                }
            }
        }

        private void FillFieldMines()
        {
            IEnumerable<Position> positions = RandomGenerator.Instance.GetUniquePointsBetween(this.minesCount, new Position(0, 0), new Position(this.ColumnsCount - 1, this.RowsCount - 1));
            foreach (Position position in positions)
            {
                this.field[position.X, position.Y] = this.factory.CreateMineCell(position, RandomGenerator.GetRandomMineType());
            }
        }

        private int CalculateInitialMinesCount()
        {
            int totalCellsCount = this.RowsCount * this.ColumnsCount;
            return RandomGenerator.Instance.GetRandomBetween(MINIMUM_MINES_PERCENT * totalCellsCount / 100, MAXIMUM_MINES_PERCENT * totalCellsCount / 100);
        }
    }
}