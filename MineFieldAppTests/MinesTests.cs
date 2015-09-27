
namespace MineFieldAppTests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MineFieldApp;
    using MineFieldApp.Mines;

    [TestClass]
    public class MinesTests
    {
        public static readonly Position DefaultMinePosition = new Position(20, 20);
        public const string TestFailedMessage = "Explosion pattern doesn't match expected pattern.";

        [TestMethod]
        public void TestTinyMine()
        {
            TinyMine mine = new TinyMine(MinesTests.DefaultMinePosition);

            //* *
            // *
            //* *
            Position[] expected = {
                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y + 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y + 1)
                                    };

            List<Position> actual = mine.Explode();

            Assert.AreEqual(expected.Length, actual.Count, MinesTests.TestFailedMessage);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual.Contains(expected[i]), MinesTests.TestFailedMessage);
            }
        }

        [TestMethod]
        public void TestSmallMine()
        {
            SmallMine mine = new SmallMine(MinesTests.DefaultMinePosition);

            //***
            //***
            //***
            Position[] expected = {
                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y + 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y + 1),

                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y + 1),
                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y)
                                    };

            List<Position> actual = mine.Explode();

            Assert.AreEqual(expected.Length, actual.Count, MinesTests.TestFailedMessage);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual.Contains(expected[i]), MinesTests.TestFailedMessage);

            }
        }

        [TestMethod]
        public void TestMediumMine()
        {
            MediumMine mine = new MediumMine(MinesTests.DefaultMinePosition);

            //  *
            // ***
            //*****
            // ***
            //  *
            Position[] expected = {
                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y + 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y + 1),

                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y + 1),
                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y - 1),
                                      new Position(MinesTests.DefaultMinePosition.X + 1, MinesTests.DefaultMinePosition.Y),
                                      new Position(MinesTests.DefaultMinePosition.X - 1, MinesTests.DefaultMinePosition.Y),

                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y + 2),
                                      new Position(MinesTests.DefaultMinePosition.X, MinesTests.DefaultMinePosition.Y - 2),
                                      new Position(MinesTests.DefaultMinePosition.X + 2, MinesTests.DefaultMinePosition.Y),
                                      new Position(MinesTests.DefaultMinePosition.X - 2, MinesTests.DefaultMinePosition.Y)
                                    };

            List<Position> actual = mine.Explode();

            Assert.AreEqual(expected.Length, actual.Count, MinesTests.TestFailedMessage);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual.Contains(expected[i]), MinesTests.TestFailedMessage);

            }
        }

        [TestMethod]
        public void TestBigMine()
        {
            BigMine mine = new BigMine(MinesTests.DefaultMinePosition);

            // ***
            //*****
            //*****
            //*****
            // ***
            List<Position> expected = new List<Position>();
            int startX = mine.Position.X - 2;
            int startY = mine.Position.Y - 2;
            int endX = startX + 4;
            int endY = startY + 4;
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (((x == startX) && (y == startY)) ||
                        ((x == endX) && (y == endY)) ||
                        ((x == startX) && (y == endY)) ||
                        ((x == endX) && (y == startY)))
                    {
                        continue;
                    }

                    expected.Add(new Position(x, y));
                }
            }

            List<Position> actual = mine.Explode();

            Assert.AreEqual(expected.Count, actual.Count, MinesTests.TestFailedMessage);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual.Contains(expected[i]), MinesTests.TestFailedMessage);

            }
        }

        [TestMethod]
        public void TestGiantMine()
        {
            GiantMine mine = new GiantMine(MinesTests.DefaultMinePosition);

            // ***
            //*****
            //*****
            //*****
            // ***
            List<Position> expected = new List<Position>();
            int startX = mine.Position.X - 2;
            int startY = mine.Position.Y - 2;
            int endX = startX + 4;
            int endY = startY + 4;
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    expected.Add(new Position(x, y));
                }
            }

            List<Position> actual = mine.Explode();

            Assert.AreEqual(expected.Count, actual.Count, MinesTests.TestFailedMessage);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual.Contains(expected[i]), MinesTests.TestFailedMessage);

            }
        }

    }
}