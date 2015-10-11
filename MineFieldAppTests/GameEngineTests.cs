namespace MineFieldAppTests
{
    using NUnit.Framework;
    using Moq;
    using MineFieldApp.Renderer;
    using MineFieldApp.Cells;
    using MineFieldApp;
    using MineFieldApp.Engines;
    using MineFieldApp.Data;
    using MineFieldApp.RNGs;
    using MineFieldApp.Cells.Mines.Factories;
    using System.Collections.Generic;

    [TestFixture]
    public class GameEngineTests
    {
        [Test]
        public void Test_EngineReturnsCorrectGameDataObjectToBeStoredInCaretaker()
        {
            var mockedRenderer = new Mock<IRenderer>();
            var mockedDamageHandler = new Mock<ICellDamageHandler>();
            var gameField = new GameField(5);

            var engine = new Engine(mockedRenderer.Object, mockedDamageHandler.Object);
            engine.Init(gameField);
            var caretaker = new GameDataCaretaker();
            caretaker.GameData = engine.CreateMemento();

            Assert.AreSame(caretaker.GameData.DamageHandler, mockedDamageHandler.Object, "Engine damage handler is not the same as the stored in memento");
            Assert.AreSame(caretaker.GameData.GameField, gameField, "Engine game field is not the same as the stored in memento");
            Assert.AreEqual(caretaker.GameData.MovesCount, engine.MovesCount, "Engine moves count is not equal to the stored in memento");
        }

        [Test]
        public void Test_EngineRestoresGameDataFromMemento()
        {
            var mockedRenderer = new Mock<IRenderer>();
            var mockedDamageHandler = new Mock<ICellDamageHandler>();
            var mockedDamageHandlerToBeReplaced = new Mock<ICellDamageHandler>();
            var gameField = new GameField(5);
            var gameFieldToBeReplaced = new GameField(4);
            int movesCount = 10;

            var gameData = new GameData(gameField, movesCount, mockedDamageHandler.Object);

            var engine = new Engine(mockedRenderer.Object, mockedDamageHandlerToBeReplaced.Object);
            engine.Init(gameFieldToBeReplaced);

            engine.SetMemento(gameData);
            var newGameData = engine.CreateMemento();

            Assert.AreSame(newGameData.DamageHandler, mockedDamageHandler.Object, "Engine damage handler is not the same as the stored in memento");
            Assert.AreSame(newGameData.GameField, gameField, "Engine game field is not the same as the stored in memento");
            Assert.AreEqual(newGameData.MovesCount, 10, "Engine moves count is not equal to the stored in memento");
        }

        [Test]
        public void Test_EngineGameOverMethodShoudlCallRendererShowGameOver()
        {
            var mockedRenderer = new Mock<IRenderer>();
            var mockedDamageHandler = new Mock<ICellDamageHandler>();

            var engine = new Engine(mockedRenderer.Object, mockedDamageHandler.Object);
            engine.GameOver();
            mockedRenderer.Verify(x => x.ShowGameOver(It.IsAny<GameData>()), Times.Once());
        }

        [Test]
        public void Test_EngineUpdateFieldWithValidPositionShoulCallRendererRefreshGameField()
        {
            var firstPosition = new Position(0, 0);
            var secondPosition = new Position(7, 7);
            var setOfPosition = new HashSet<Position>();
            setOfPosition.Add(firstPosition);
            setOfPosition.Add(secondPosition);

            var mockedRenderer = new Mock<IRenderer>();
            var mockedDamageHandler = new Mock<ICellDamageHandler>();

            var mockedRandomGenerator = new Mock<IRandomGenerator>();
            mockedRandomGenerator.Setup(x => x.GetUniquePointsBetween(It.IsAny<int>(), It.IsAny<Position>(), It.IsAny<Position>())).Returns(setOfPosition);
            mockedRandomGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var gameField = new GameField(mockedRandomGenerator.Object, new RandomMineFactory(), 8);

            var engine = new Engine(mockedRenderer.Object, mockedDamageHandler.Object);
            engine.Init(gameField);
  
            engine.UpdateField(firstPosition);
            mockedRenderer.Verify(x => x.RefreshGameField(It.IsAny<GameField>()), Times.Once());
        }

        [Test]
        public void Test_EngineUpdateFieldWithValidPositionAndOneMineShouldCallRendererGameOver()
        {
            var firstPosition = new Position(0, 0);
            var setOfPosition = new HashSet<Position>();
            setOfPosition.Add(firstPosition);

            var mockedRenderer = new Mock<IRenderer>();
            var mockedDamageHandler = new Mock<ICellDamageHandler>();

            var mockedRandomGenerator = new Mock<IRandomGenerator>();
            mockedRandomGenerator.Setup(x => x.GetUniquePointsBetween(It.IsAny<int>(), It.IsAny<Position>(), It.IsAny<Position>())).Returns(setOfPosition);
            mockedRandomGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var gameField = new GameField(mockedRandomGenerator.Object, new RandomMineFactory(), 8);

            var engine = new Engine(mockedRenderer.Object, mockedDamageHandler.Object);
            engine.Init(gameField);

            engine.UpdateField(firstPosition);
            mockedRenderer.Verify(x => x.ShowGameOver(It.IsAny<GameData>()), Times.Once());
        }

        [Test]
        public void Test_EngineUpdateFieldWithInvalidPositionShouldCallRendererShowError()
        {
            var firstPosition = new Position(0, 0);
            var setOfPosition = new HashSet<Position>();
            setOfPosition.Add(firstPosition);

            var mockedRenderer = new Mock<IRenderer>();
            var mockedDamageHandler = new Mock<ICellDamageHandler>();

            var mockedRandomGenerator = new Mock<IRandomGenerator>();
            mockedRandomGenerator.Setup(x => x.GetUniquePointsBetween(It.IsAny<int>(), It.IsAny<Position>(), It.IsAny<Position>())).Returns(setOfPosition);
            mockedRandomGenerator.Setup(x => x.GetRandomBetween(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var gameField = new GameField(mockedRandomGenerator.Object, new RandomMineFactory(), 8);

            var engine = new Engine(mockedRenderer.Object, mockedDamageHandler.Object);
            engine.Init(gameField);

            engine.UpdateField(new Position(0, 1));
            mockedRenderer.Verify(x => x.ShowErrorMessage(It.IsAny<string>()), Times.Once());
        }
    }
}
