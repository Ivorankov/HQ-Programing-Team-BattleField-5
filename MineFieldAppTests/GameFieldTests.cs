namespace MineFieldAppTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MineFieldApp;

    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        public void Test_IsInRangeShouldReturnTrueWithValidPosition()
        {
            var field = new GameField(10);
            var result = field.IsInRange(new Position(0, 0));
            Assert.AreEqual(true, result);    
        }

        [TestMethod]
        public void Test_IsInRangeShouldReturnFalseWithInvalidPositionPositiveRowCol()
        {
            var field = new GameField(10);
            var result = field.IsInRange(new Position(11, 11));
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsInRangeShouldReturnFalseWithInvalidPositionNegativeRowCol()
        {
            var field = new GameField(10);
            var result = field.IsInRange(new Position(-1, 2));
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_HasMinesLeftShouldReturnTrueWhenMinesCountGreaterThanZero()
        {
            var field = new GameField(10);
            field.MinesCount = 2;
            var result = field.HasMinesLeft();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_HasMinesLeftShouldReturnFalseWhenMinesCountLessThanZero()
        {
            var field = new GameField(10);
            field.MinesCount = -2;
            var result = field.HasMinesLeft();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_HasMinesLeftShouldReturnFalseWhenMinesCountEqualToZero()
        {
            var field = new GameField(10);
            field.MinesCount = 0;
            var result = field.HasMinesLeft();
            Assert.AreEqual(false, result);
        }
    }
}
