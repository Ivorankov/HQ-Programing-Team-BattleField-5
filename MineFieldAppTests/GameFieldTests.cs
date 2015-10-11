namespace MineFieldAppTests
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GameFieldTests
    {
        [Test]
        public void Test_IsInRangeShouldReturnTrueWithValidPosition()
        {
            var field = new GameField(10);
            var result = field.IsInRange(new Position(0, 0));
            Assert.AreEqual(true, result);    
        }

        [Test]
        public void Test_IsInRangeShouldReturnFalseWithInvalidPositionPositiveRowCol()
        {
            var field = new GameField(10);
            var result = field.IsInRange(new Position(11, 11));
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_IsInRangeShouldReturnFalseWithInvalidPositionNegativeRowCol()
        {
            var field = new GameField(10);
            var result = field.IsInRange(new Position(-1, 2));
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_HasMinesLeftShouldReturnTrueWhenMinesCountGreaterThanZero()
        {
            var field = new GameField(10);
            field.MinesCount = 2;
            var result = field.HasMinesLeft();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_HasMinesLeftShouldReturnFalseWhenMinesCountLessThanZero()
        {
            var field = new GameField(10);
            field.MinesCount = -2;
            var result = field.HasMinesLeft();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_HasMinesLeftShouldReturnFalseWhenMinesCountEqualToZero()
        {
            var field = new GameField(10);
            field.MinesCount = 0;
            var result = field.HasMinesLeft();
            Assert.AreEqual(false, result);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 4)]
        [TestCase(4, 0)]
        [TestCase(2, 3)]
        [TestCase(4, 4)]
        public void Test_GameFieldShouldReturnCellWithValidCoordinates(int X, int Y)
        {
            var field = new GameField(5);
            var cell = field[X, Y];
            Assert.IsInstanceOf<Cell>(cell, "Game field does not return a valid cell object");
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(5, 0)]
        [TestCase(-1, 0)]
        [TestCase(2, 30)]
        [TestCase(5, 5)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_GameFieldShouldThrowWithInvalidCoordinates(int X, int Y)
        {
            var field = new GameField(5);
            var cell = field[X, Y];
        }
    }
}
