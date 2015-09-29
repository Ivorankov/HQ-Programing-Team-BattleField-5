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


        public GameField(IRandomGenerator random, IMineFactory mineFactory, int size)
        {
            this.Random = random;
            this.MineFactory = mineFactory;

            this.Field = new Cell[size, size];
            this.MinesCount = this.CalculateInitialMinesCount();
            this.FillFieldMines();
            this.FillFieldWithEmptyCells();
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
            : this(RandomGenerator.Instance, new RandomMineFactory(), size)
        {

        }

        private IRandomGenerator Random { get; set; }

        private IMineFactory MineFactory { get; set; }

        private Cell[,] Field { get; set; }

        public Cell this[int i, int j]
        {
            get
            {
                if (this.IsInRange(new Position(i, j)))
                {
                    return Field[i, j];
                }

                throw new IndexOutOfRangeException();
            }
        }

        public int MinesCount { get; set; }

        public int RowsCount
        {
            get
            {
                return this.Field.GetLength(0);
            }
        }

        public int ColumnsCount
        {
            get
            {
                return this.Field.GetLength(1);
            }
        }

        public bool IsInRange(Position position)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < this.RowsCount && position.Y < this.ColumnsCount;
        }

        public bool HasMinesLeft()
        {
            return MinesCount > 0;
        }

        private void FillFieldWithEmptyCells()
        {
            for (int i = 0; i < this.RowsCount; i++)
            {
                for (int j = 0; j < this.ColumnsCount; j++)
                {
                    if (this.Field[i, j] == null)
                    {
                        this.Field[i, j] = new Cell(new Position(j, i));
                    }
                }
            }
        }

        private void FillFieldMines()
        {
            HashSet<Position> positions = RandomGenerator.Instance.GetUniquePointsBetween(this.MinesCount, new Position(0, 0), new Position(this.ColumnsCount - 1, this.RowsCount - 1));
            foreach (Position position in positions)
            {
                this.Field[position.Y, position.X] = this.MineFactory.Create(position);
            }
        }

        private int CalculateInitialMinesCount()
        {
            int totalCellsCount = this.RowsCount * this.ColumnsCount;
            return RandomGenerator.Instance.GetRandomBetween(MINIMUM_MINES_PERCENT * totalCellsCount / 100, MAXIMUM_MINES_PERCENT * totalCellsCount / 100);
        }
    }
}