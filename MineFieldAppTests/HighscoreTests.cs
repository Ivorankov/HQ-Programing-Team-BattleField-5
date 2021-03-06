﻿//-----------------------------------------------------------------------
// <copyright file="HighscoreTests.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
// <summary>
// Contains Tests for Highscore class
// </summary>
//-----------------------------------------------------------------------
namespace MineFieldAppTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MineFieldApp;

    /// <summary>
    /// A class for testing <see cref="HighscoreLogger"/> class
    /// </summary>
    [TestClass]
    public class HighscoreTests
    {
        /// <summary>
        /// Method invoked after every unit test. It cleans up high scores list and file.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            HighscoreLogger.Instance.ClearHighscores();
        }

        /// <summary>
        /// Checks if <see cref="HighscoreLogger"/> class is singleton by comparing two instances
        /// </summary>
        [TestMethod]
        public void CheckIfHighscorerIsSingleton()
        {
            HighscoreLogger firstScorer = HighscoreLogger.Instance;
            HighscoreLogger secondScorer = HighscoreLogger.Instance;

            Assert.AreSame(firstScorer, secondScorer, "Highscore does not implement singleton");
        }

        /// <summary>
        /// Checks adding high score to the list with high scores
        /// </summary>
        [TestMethod]
        public void CheckIfHighscorerAddsScoreToList()
        {
            var playerName = "Ivan";
            var playerPoints = 243.98;

            HighscoreLogger scorer = HighscoreLogger.Instance;

            scorer.AddHighscore(playerName, playerPoints);

            var highscore = scorer.Highscores[0];

            Assert.AreEqual(1, scorer.Highscores.Count, "Highscores count is not correct");
            Assert.AreEqual(playerName, highscore.PlayerName, "Player name of highscore is not the same as the given");
            Assert.AreEqual(playerPoints, highscore.Points, "Player points of highscore is not the same as the given");
        }

        /// <summary>
        /// Checks adding high score to the file with high scores
        /// </summary>
        [TestMethod]
        public void CheckIfHighscorerAddsScoreToFile()
        {
            var playerName = "John";
            var playerPoints = 105;

            HighscoreLogger scorer = HighscoreLogger.Instance;

            scorer.AddHighscore(playerName, playerPoints);

            XmlSerializer reader = new XmlSerializer(typeof(List<Score>));
            StreamReader file = new StreamReader(Path.GetFullPath("../../Highscores/highscores.xml"));
            var highscores = (List<Score>)reader.Deserialize(file);
            var highscore = highscores[0];

            file.Close();

            Assert.AreEqual(playerName, highscore.PlayerName, "Player name of highscore is not the same as the given");
            Assert.AreEqual(playerPoints, highscore.Points, "Player points of highscore is not the same as the given");
        }

        /// <summary>
        /// Checks if reading from empty file creates empty list with high scores 
        /// </summary>
        [TestMethod]
        public void CheckIfHighscorerReadEmptyFileCorrectly()
        {
            HighscoreLogger scorer = HighscoreLogger.Instance;

            scorer.LoadHighscores();

            Assert.AreEqual(0, scorer.Highscores.Count, "Scorer does not read from empty file correctly");
        }

        /// <summary>
        /// Checks if reading from non empty file with high scores is correct
        /// </summary>
        [TestMethod]
        public void CheckIfHighscorerReadNonEmptyFile()
        {
            var scores = new List<Score>();
            scores.Add(new Score("Ivan", 234.5));
            scores.Add(new Score("Petur", 20000));
            scores.Add(new Score("Gosho", 5));

            XmlSerializer writer = new XmlSerializer(typeof(List<Score>));
            StreamWriter file = new StreamWriter(Path.GetFullPath("../../Highscores/highscores.xml"), false);

            writer.Serialize(file, scores);

            file.Close();

            HighscoreLogger scorer = HighscoreLogger.Instance;
            scorer.LoadHighscores();
            var scoreToCheck = scorer.Highscores[1];

            Assert.AreEqual(3, scorer.Highscores.Count, "Highscores count is not correct");
            Assert.AreEqual("Petur", scoreToCheck.PlayerName, "Player name read from file is not correct");
            Assert.AreEqual(20000, scoreToCheck.Points, "Player points read from file are not correct");
        }

        /// <summary>
        /// Checks if high scores are correctly sorted by points in decreasing order
        /// </summary>
        [TestMethod]
        public void CheckIfHighscorerSortsScoresByScore()
        {
            HighscoreLogger scorer = HighscoreLogger.Instance;

            scorer.AddHighscore("second", 230);
            scorer.AddHighscore("third", 100);
            scorer.AddHighscore("first", 1000);

            Assert.AreEqual("third", scorer.Highscores[0].PlayerName, "Highscores are not sorted decreasingly");
            Assert.AreEqual("second", scorer.Highscores[1].PlayerName, "Highscores are not sorted decreasingly");
            Assert.AreEqual("first", scorer.Highscores[2].PlayerName, "Highscores are not sorted decreasingly");
        }
    }
}
