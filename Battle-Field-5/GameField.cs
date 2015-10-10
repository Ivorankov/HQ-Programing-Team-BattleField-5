﻿//-----------------------------------------------------------------------
// <copyright file="GameField.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains GameField class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;
    using Cells;
    using Cells.Mines;
    using Cells.Mines.Factories;
    using RNGs;

    /// <summary>
    /// A class representing the game field.
    /// </summary>
    public class GameField
    {
        private const int MINIMUM_MINES_PERCENT = 15;

        private const int MAXIMUM_MINES_PERCENT = 30;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameField" /> class.
        /// </summary>
        /// <param name="random">Random generator.</param>
        /// <param name="mineFactory">Mine factory.</param>
        /// <param name="size">Size of the game field.</param>
        public GameField(IRandomGenerator random, IMineFactory mineFactory, int size)
        {
            this.Random = random;
            this.MineFactory = mineFactory;
            this.Field = new Cell[size, size];
            this.MinesCount = this.CalculateInitialMineCount();
            this.FillFieldWithEmptyCells();
            this.FillFieldMines();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameField" /> class.
        /// </summary>
        /// <param name="random">Random generator.</param>
        /// <param name="size">Size of the game field.</param>
        public GameField(IRandomGenerator random, int size)
            : this(random, new RandomMineFactory(), size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameField" /> class.
        /// </summary>
        /// <param name="mineFactory">Mine factory.</param>
        /// <param name="size">Size of the game field.</param>
        public GameField(IMineFactory mineFactory, int size)
            : this(RandomGenerator.Instance, mineFactory, size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameField" /> class.
        /// </summary>
        /// <param name="size">Size of the game field.</param>
        public GameField(int size)
            : this(RandomGenerator.Instance, new RandomMineFactory(), size)
        {
        }

        private IRandomGenerator Random { get; set; }

        private IMineFactory MineFactory { get; set; }

        private Cell[,] Field { get; set; }

        /// <summary>
        /// Gets the cell on the selected position.
        /// </summary>
        /// <param name="row">The X coordinate.</param>
        /// <param name="col">The Y coordinate.</param>
        /// <returns>The cell on the position.</returns>
        public Cell this[int row, int col]
        {
            get
            {
                if (this.IsInRange(new Position(row, col)))
                {
                    return this.Field[row, col];
                }

                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets or sets count of the mines on the field.
        /// </summary>
        /// <value>Mines count.</value>
        public int MinesCount { get; set; }

        /// <summary>
        /// Gets count of the rows.
        /// </summary>
        /// <value>Rows count.</value>
        public int RowsCount
        {
            get
            {
                return this.Field.GetLength(0);
            }
        }

        /// <summary>
        /// Gets count of the columns.
        /// </summary>
        /// <value>Columns count.</value>
        public int ColumnsCount
        {
            get
            {
                return this.Field.GetLength(1);
            }
        }

        /// <summary>
        /// Checks if position is part of the field.
        /// </summary>
        /// <param name="position">The position to be checked.</param>
        /// <returns>True if the position is in range of the field,false otherwise.</returns>
        public bool IsInRange(Position position)
        {
            return position.Row >= 0 && position.Col >= 0 && position.Row < this.RowsCount && position.Col < this.ColumnsCount;
        }

        /// <summary>
        /// Checks if there are mines left on the field.
        /// </summary>
        /// <returns>True if there are mines left, false otherwise.</returns>
        public bool HasMinesLeft()
        {
            return MinesCount > 0;
        }

        /// <summary>
        /// Fills whole field with empty cells.
        /// </summary>
        private void FillFieldWithEmptyCells()
        {
            for (int row = 0; row < this.RowsCount; row++)
            {
                for (int col = 0; col < this.ColumnsCount; col++)
                {
                    this.Field[row, col] = new EmptyCell(new Position(row, col));
                }
            }
        }

        /// <summary>
        /// Fills field with mines.
        /// </summary>
        private void FillFieldMines()
        {
            HashSet<Position> positions = RandomGenerator.Instance.GetUniquePointsBetween(this.MinesCount, new Position(0, 0), new Position(this.ColumnsCount - 1, this.RowsCount - 1));
            foreach (Position position in positions)
            {
                var cell = this.Field[position.Row, position.Col];
                Mine mine = this.MineFactory.Create(cell);
                this.Field[position.Row, position.Col] = mine;
            }
        }

        private int CalculateInitialMineCount()
        {
            int totalCellsCount = this.RowsCount * this.ColumnsCount;
            return RandomGenerator.Instance.GetRandomBetween(MINIMUM_MINES_PERCENT * totalCellsCount / 100, MAXIMUM_MINES_PERCENT * totalCellsCount / 100);
        }

        /// <summary>
        /// Makes the field react to explosion.
        /// </summary>
        /// <param name="positions">Position of the mine.</param>
        /// <param name="damageHandler">Cells damage handler.</param>
        public void ReactToExplosion(IList<Position> positions, ICellDamageHandler damageHandler)
        {
            foreach (var position in positions)
            {
                if (this.IsInRange(position))
                {
                    var currentCell = this.Field[position.Row, position.Col];

                    if (!currentCell.IsDestroyed)
                    {
                        if (currentCell is Mine)
                        {
                            --this.MinesCount;
                        }

                        this.Field[position.Row, position.Col].TakeDamage(damageHandler);
                    }
                }
            }
        }
    }
}