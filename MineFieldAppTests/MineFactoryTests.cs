namespace MineFieldAppTests
{
    using NUnit.Framework;
    using Moq;
    using MineFieldApp.RNGs;
    using MineFieldApp.Cells.Mines.Factories;
    using MineFieldApp.Cells;
    using MineFieldApp;
    using MineFieldApp.Cells.Mines;
    using System;

    [TestFixture]
    public class MineFactoryTests
    {
        [Test]
        public void Test_MineFactoryShouldReturnTinyMine()
        {
            var mockedGenerator = new Mock<IRandomGenerator>();
            mockedGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            var randomMineFactory = new RandomMineFactory(mockedGenerator.Object);
            var cell = new EmptyCell(new Position(0, 0));
            var mine = randomMineFactory.Create(cell);

            Assert.IsInstanceOf<TinyMine>(mine, "Returned mine is not the right type");
        }

        [Test]
        public void Test_MineFactoryShouldReturnSmallMine()
        {
            var mockedGenerator = new Mock<IRandomGenerator>();
            mockedGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var randomMineFactory = new RandomMineFactory(mockedGenerator.Object);
            var cell = new EmptyCell(new Position(0, 0));
            var mine = randomMineFactory.Create(cell);

            Assert.IsInstanceOf<SmallMine>(mine, "Returned mine is not the right type");
        }

        [Test]
        public void Test_MineFactoryShouldReturnMediumMine()
        {
            var mockedGenerator = new Mock<IRandomGenerator>();
            mockedGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(2);

            var randomMineFactory = new RandomMineFactory(mockedGenerator.Object);
            var cell = new EmptyCell(new Position(0, 0));
            var mine = randomMineFactory.Create(cell);

            Assert.IsInstanceOf<MediumMine>(mine, "Returned mine is not the right type");
        }

        [Test]
        public void Test_MineFactoryShouldReturnBigMine()
        {
            var mockedGenerator = new Mock<IRandomGenerator>();
            mockedGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(3);

            var randomMineFactory = new RandomMineFactory(mockedGenerator.Object);
            var cell = new EmptyCell(new Position(0, 0));
            var mine = randomMineFactory.Create(cell);

            Assert.IsInstanceOf<BigMine>(mine, "Returned mine is not the right type");
        }

        [Test]
        public void Test_MineFactoryShouldReturnGiantMine()
        {
            var mockedGenerator = new Mock<IRandomGenerator>();
            mockedGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(4);

            var randomMineFactory = new RandomMineFactory(mockedGenerator.Object);
            var cell = new EmptyCell(new Position(0, 0));
            var mine = randomMineFactory.Create(cell);

            Assert.IsInstanceOf<GiantMine>(mine, "Returned mine is not the right type");
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_MineFactoryShouldThrowIndexOutOfRangeExceptionWithInvalidMineIndex()
        {
            var mockedGenerator = new Mock<IRandomGenerator>();
            mockedGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(5);

            var randomMineFactory = new RandomMineFactory(mockedGenerator.Object);
            var cell = new EmptyCell(new Position(0, 0));
            var mine = randomMineFactory.Create(cell);
        }
    }
}
