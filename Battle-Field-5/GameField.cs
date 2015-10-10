namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;
    using Cells;
    using Cells.Mines;
    using Cells.Mines.Factories;
    using RNGs;

    public class GameField
    {
        private const int MinimumMinesPercent = 15;

        private const int MaximumMinesPercent = 30;

        private IRandomGenerator random;

        private IMineFactory mineFactory;

        private Cell[,] field;

        public GameField(IRandomGenerator random, IMineFactory mineFactory, int size)
        {
            this.random = random;
            this.mineFactory = mineFactory;
            this.field = new Cell[size, size];
            this.MinesCount = this.CalculateInitialMineCount();
            this.FillFieldWithEmptyCells();
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
            : this(RandomGenerator.Instance, new RandomMineFactory(), size)
        {
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

        public int MinesCount { get; set; }

        public Cell this[int row, int col]
        {
            get
            {
                if (this.IsInRange(new Position(row, col)))
                {
                    return this.field[row, col];
                }

                throw new IndexOutOfRangeException();
            }
        }

        public bool IsInRange(Position position)
        {
            return position.Row >= 0 && position.Col >= 0 && position.Row < this.RowsCount && position.Col < this.ColumnsCount;
        }

        public bool HasMinesLeft()
        {
            return this.MinesCount > 0;
        }

        public void ReactToExplosion(IList<Position> positions, ICellDamageHandler damageHandler)
        {
            foreach (var position in positions)
            {
                if (this.IsInRange(position))
                {
                    var currentCell = this.field[position.Row, position.Col];

                    if (!currentCell.IsDestroyed)
                    {
                        if (currentCell is Mine)
                        {
                            --this.MinesCount;
                        }

                        this.field[position.Row, position.Col].TakeDamage(damageHandler);
                    }
                }
            }
        }

        private void FillFieldWithEmptyCells()
        {
            for (int row = 0; row < this.RowsCount; row++)
            {
                for (int col = 0; col < this.ColumnsCount; col++)
                {
                    this.field[row, col] = new EmptyCell(new Position(row, col));
                }
            }
        }

        private void FillFieldMines()
        {
            HashSet<Position> positions = RandomGenerator.Instance.GetUniquePointsBetween(this.MinesCount, new Position(0, 0), new Position(this.ColumnsCount - 1, this.RowsCount - 1));
            foreach (Position position in positions)
            {
                var cell = this.field[position.Row, position.Col];
                Mine mine = this.mineFactory.Create(cell);
                this.field[position.Row, position.Col] = mine;
            }
        }

        private int CalculateInitialMineCount()
        {
            int totalCellsCount = this.RowsCount * this.ColumnsCount;
            return RandomGenerator.Instance.GetRandomBetween(MinimumMinesPercent * totalCellsCount / 100, MaximumMinesPercent * totalCellsCount / 100);
        }
    }
}