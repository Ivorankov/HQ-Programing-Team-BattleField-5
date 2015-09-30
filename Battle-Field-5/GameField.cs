namespace BattleField
{
    using BattleField.Enums;
    using System;
    using System.Collections.Generic;

    public class GameField
    {
        private const int MINIMUM_MINES_PERCENT = 15;
        private const int MAXIMUM_MINES_PERCENT = 30;

        private Cell[,] field;
        private Cell.CellFactory factory;
        private int minesCount;

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

        public GameField(int size)
        {
            this.field = new Cell[size, size];
            this.factory = Cell.CreateFactory(this);
            this.FillFieldWithEmptyCells();
            this.minesCount = this.CalculateInitialMinesCount();
            this.FillFieldMines();
        }

        public void ExplodeCell(Position position)
        {
            if (this.IsInRange(position))
            {
                Cell currentCell = this.field[position.X, position.Y];
                if (currentCell.Type != CellType.BOMBED && (currentCell.Type & CellType.MINE) != 0)
                {
                    --this.minesCount;
                }

                this.field[position.X, position.Y].ReactToExplosion();
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

        public void ActivateMine(Position position)
        {
            this.field[position.X, position.Y].ExplodeCommand.Execute();
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
            IEnumerable<Position> positions = RandomGenerator.GetUniquePointsBetween(this.minesCount, this.RowsCount, this.ColumnsCount);
            foreach (Position position in positions)
            {
                this.field[position.X, position.Y] = this.factory.CreateMineCell(position, RandomGenerator.GetRandomMineType());
            }
        }

        private int CalculateInitialMinesCount()
        {
            int totalCellsCount = this.RowsCount * this.ColumnsCount;
            return RandomGenerator.GetRandomBetween(MINIMUM_MINES_PERCENT * totalCellsCount / 100, MAXIMUM_MINES_PERCENT * totalCellsCount / 100);
        }
    }
}