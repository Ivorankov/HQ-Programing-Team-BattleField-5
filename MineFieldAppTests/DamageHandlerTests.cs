namespace MineFieldAppTests
{
    using NUnit.Framework;
    using Moq;
    using MineFieldApp.Cells;
    using MineFieldApp;
    using MineFieldApp.Cells.Mines;

    [TestFixture]
    public class DamageHandlerTests
    {
        [Test]
        public void Test_CheckIfDamageHandlerDamagesEmptyCell()
        {
            var mockDamageHandler = new Mock<ICellDamageHandler>();
            var cell = new EmptyCell(new Position(0, 0));

            cell.TakeDamage(mockDamageHandler.Object);
            mockDamageHandler.Verify(x => x.Damage(cell), Times.Once());
        }

        [Test]
        public void Test_CheckIfDamageHandlerDamagesMine()
        {
            var mockDamageHandler = new Mock<ICellDamageHandler>();
            var cell = new EmptyCell(new Position(0, 0));
            var mine = new SmallMine(cell);

            mine.TakeDamage(mockDamageHandler.Object);
            mockDamageHandler.Verify(x => x.Damage(mine), Times.Once());
        }

        [Test]
        public void Test_CheckIfDamageHandlerDestroysCell()
        {
            var cell = new EmptyCell(new Position(0, 0));

            cell.TakeDamage(new DefaultDamageHandler());
            Assert.IsTrue(cell.IsDestroyed);
        }

        [Test]
        public void Test_CheckIfDamageHandlerDestroysMine()
        {
            var cell = new EmptyCell(new Position(0, 0));
            var mine = new GiantMine(cell);

            mine.TakeDamage(new DefaultDamageHandler());
            Assert.IsTrue(mine.IsDestroyed);
        }
    }
}
