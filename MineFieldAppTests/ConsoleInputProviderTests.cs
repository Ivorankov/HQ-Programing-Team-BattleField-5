namespace MineFieldAppTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleInputProviderTests
    {
        private const string ValidFieldSizeInput = "5";
        private const string ValidPlayerNameInput = "tea";

        [TestMethod]
        public void Test_GetFieldSize_WithValidValue_LowerBoundry_One()
        {
            string[] input = new string[] { "1" };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(1, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithValidValue_Five()
        {
            string[] input = new string[] { ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(int.Parse(ValidFieldSizeInput), inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithValidValue_HigherBoundry_Ten()
        {
            string[] input = new string[] { "10" };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(10, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithInvalidValue_EmptyString()
        {
            string[] input = new string[] { String.Empty, ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("", inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithInvalidValue_Zero()
        {
            string[] input = new string[] { "0", ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(0, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithInvalidValue_Eleven()
        {
            string[] input = new string[] { "11", ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(11, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithInvalidValue_ABC()
        {
            string[] input = new string[] { "ABC", ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("ABC", inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithInvalidValue_Double()
        {
            string[] input = new string[] { "68.783", ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(68.783, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetFieldSize_WithInvalidValue_BiggerThanDouble()
        {
            string[] input = new string[] { "68.7831111111111111111111111111", ValidFieldSizeInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(68.7831111111111111111111111111, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithValidValue()
        {
            string[] input = new string[] { ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(ValidPlayerNameInput, inputProvider.GetPlayerName());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithInvalidValue_EmptyString()
        {
            string[] input = new string[] { String.Empty, ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("", inputProvider.GetPlayerName());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithInvalidValue_NotWordCharacterAtTheBegining()
        {
            string[] input = new string[] { "!@~tea", ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("!@~tea", inputProvider.GetPlayerName());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithInvalidValue_NotWordCharacterAtTheEnd()
        {
            string[] input = new string[] { "tea$%^", ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("tea$%^", inputProvider.GetPlayerName());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithInvalidValue_NotWordCharacterInTheMiddle()
        {
            string[] input = new string[] { "te&*(a", ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("te&*(a", inputProvider.GetPlayerName());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithInvalidValue_NotWordCharacterInMixedPlaces()
        {
            string[] input = new string[] { "!@te&*(a#^", ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("!@te&*(a#^", inputProvider.GetPlayerName());
        }

        [TestMethod]
        public void Test_GetPlayerName_WithInvalidValue_OnlySpecialSymbols()
        {
            string[] input = new string[] { "~!@#$%^&*()_+", ValidPlayerNameInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("~!@#$%^&*()_+", inputProvider.GetPlayerName());
        }
    }
}
