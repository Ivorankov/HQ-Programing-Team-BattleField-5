namespace MineFieldAppTests
{
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Cells.Mines;
    using MineFieldApp.Cells.Mines.Factories;
    using MineFieldApp.RNGs;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class MinePatternsTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(7)]
        public void Test_MineAssistantShouldReturnValidPattern(int radius)
        {
            var startingPosition = new Position(5, 5);
            var pattern = MineAssistant.GetNormalExplosion(startingPosition, radius);
            var expectedPostions = new List<Position>();

            for (int x = startingPosition.Row - radius; x < (startingPosition.Row + radius + 1); x++)
            {
                for (int y = startingPosition.Col - radius; y < (startingPosition.Col + radius + 1); y++)
                {
                    expectedPostions.Add(new Position(x, y));
                }
            }

            for (int i = 0; i < pattern.Count; i++)
            {
                Assert.IsTrue(expectedPostions[i] == pattern[i]);
            }
        }

        [Test]
        public void Test_TinyMinePattern()
        {
            var startingPosition = new Position(5, 5);
            var expectedPostions = new List<Position>();

            expectedPostions.Add(startingPosition);
            expectedPostions.Add(new Position(startingPosition.Row - 1, startingPosition.Col - 1));
            expectedPostions.Add(new Position(startingPosition.Row + 1, startingPosition.Col + 1));
            expectedPostions.Add(new Position(startingPosition.Row + 1, startingPosition.Col - 1));
            expectedPostions.Add(new Position(startingPosition.Row - 1, startingPosition.Col + 1));

            var mine = new TinyMine(new EmptyCell(startingPosition));
            var pattern = mine.GetExplodingPattern();

            foreach (var pos1 in pattern)
            {
                var positionMatch = false;

                foreach (var pos2 in expectedPostions)
                {
                    if (pos1 == pos2)
                    {
                        positionMatch = true;
                    }
                }

                if (positionMatch == false)
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public void Test_SmallMinePattern()
        {
            var startingPosition = new Position(5, 5);
            var expectedPostions = MineAssistant.GetNormalExplosion(startingPosition, 1);           

            var mine = new SmallMine(new EmptyCell(startingPosition));
            var pattern = mine.GetExplodingPattern();

            foreach (var pos1 in pattern)
            {
                var positionMatch = false;

                foreach (var pos2 in expectedPostions)
                {
                    if (pos1 == pos2)
                    {
                        positionMatch = true;
                    }
                }

                if (positionMatch == false)
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public void Test_MediumMinePattern()
        {
            var startingPosition = new Position(5, 5);
            var expectedPostions = MineAssistant.GetNormalExplosion(startingPosition, 1);

            expectedPostions.Add(new Position(startingPosition.Row, startingPosition.Col - 2));
            expectedPostions.Add(new Position(startingPosition.Row, startingPosition.Col + 2));
            expectedPostions.Add(new Position(startingPosition.Row - 2, startingPosition.Col));
            expectedPostions.Add(new Position(startingPosition.Row + 2, startingPosition.Col));

            var mine = new MediumMine(new EmptyCell(startingPosition));
            var pattern = mine.GetExplodingPattern();

            foreach (var pos1 in pattern)
            {
                var positionMatch = false;

                foreach (var pos2 in expectedPostions)
                {
                    if (pos1 == pos2)
                    {
                        positionMatch = true;
                    }
                }

                if (positionMatch == false)
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public void Test_BigMinePattern()
        {
            var startingPosition = new Position(5, 5);
            var tempPositions = MineAssistant.GetNormalExplosion(startingPosition, 2);
            var expectedPositions = new List<Position>();

            var startRow = startingPosition.Row - 2;
            var startCol = startingPosition.Col - 2;
            var endRow = startingPosition.Row + 2;
            var endCol = startingPosition.Col + 2;
            foreach (var pos in tempPositions)
            {
                if (((pos.Row == startRow) && (pos.Col == startCol)) ||
                        ((pos.Row == endRow) && (pos.Col == endCol)) ||
                        ((pos.Row == startRow) && (pos.Col == endCol)) ||
                        ((pos.Row == endRow) && (pos.Col == startCol)))
                {
                    continue;
                }

                expectedPositions.Add(pos);
            }

            var mine = new BigMine(new EmptyCell(startingPosition));
            var pattern = mine.GetExplodingPattern();

            foreach (var pos1 in pattern)
            {
                var positionMatch = false;

                foreach (var pos2 in expectedPositions)
                {
                    if (pos1 == pos2)
                    {
                        positionMatch = true;
                    }
                }

                if (positionMatch == false)
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public void Test_GiantMinePattern()
        {
            var startingPosition = new Position(5, 5);
            var expectedPostions = MineAssistant.GetNormalExplosion(startingPosition, 2);

            var mine = new GiantMine(new EmptyCell(startingPosition));
            var pattern = mine.GetExplodingPattern();

            foreach (var pos1 in pattern)
            {
                var positionMatch = false;

                foreach (var pos2 in expectedPostions)
                {
                    if (pos1 == pos2)
                    {
                        positionMatch = true;
                    }
                }

                if (positionMatch == false)
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }
    }
}
