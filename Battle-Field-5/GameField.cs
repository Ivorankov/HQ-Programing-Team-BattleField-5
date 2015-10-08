namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;
    using RNGs;
    using Cells;
    using Cells.Mines;
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
            this.MinesCount = this.CalculateInitialMineCount();
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

        public Cell this[int row, int col]
        {
            get
            {
                if (this.IsInRange(new Position(row, col)))
                {
                    return Field[row, col];
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
            return position.Row >= 0 && position.Col >= 0 && position.Row < this.RowsCount && position.Col < this.ColumnsCount;
        }

        public bool HasMinesLeft()
        {
            return MinesCount > 0;
        }

        private void FillFieldWithEmptyCells()
        {
            for (int row = 0; row < this.RowsCount; row++)
            {
                for (int col = 0; col < this.ColumnsCount; col++)
                {
                    if (this.Field[row, col] == null)
                    {
                        this.Field[row, col] = new EmptyCell(new Position(row, col));
                    }
                }
            }
        }

        private void FillFieldMines()
        {
            HashSet<Position> positions = RandomGenerator.Instance.GetUniquePointsBetween(this.MinesCount, new Position(0, 0), new Position(this.ColumnsCount - 1, this.RowsCount - 1));
            foreach (Position position in positions)
            {
                Mine mine = this.MineFactory.Create(position, this);
                this.Field[position.Row, position.Col] = mine;
            }
        }

        private int CalculateInitialMineCount()
        {
            int totalCellsCount = this.RowsCount * this.ColumnsCount;
            return RandomGenerator.Instance.GetRandomBetween(MINIMUM_MINES_PERCENT * totalCellsCount / 100, MAXIMUM_MINES_PERCENT * totalCellsCount / 100);
        }

        public void ReactToExplosion(IList<Position> positions, ICellDamageHandler damageHandler)
        {
            foreach (var position in positions)
            {
                if (this.IsInRange(position) && this.Field[position.Row, position.Col].Status != CellStatus.Destroyed)
                {
                    this.Field[position.Row, position.Col].TakeDamage(damageHandler);
                }
            }
        }
    }
}