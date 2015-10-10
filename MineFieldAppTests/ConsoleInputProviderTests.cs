namespace MineFieldAppTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleInputProviderTests
    {
        private const string ValidInput = "5";

        [TestMethod]
        public void Test_WithValidValue_LowerBoundry_One()
        {
            string[] input = new string[] { "1" };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(1, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithValidValue_Seven()
        {
            string[] input = new string[] { ValidInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(5, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithValidValue_HigherBoundry_Ten()
        {
            string[] input = new string[] { "10" };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreEqual(10, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithInvalidValue_Zero()
        {
            string[] input = new string[] { "0", ValidInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(0, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithInvalidValue_Eleven()
        {
            string[] input = new string[] { "11", ValidInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(11, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithInvalidValue_ABC()
        {
            string[] input = new string[] { "ABC", ValidInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual("ABC", inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithInvalidValue_Double()
        {
            string[] input = new string[] { "68.783", ValidInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(68.783, inputProvider.GetFieldSize());
        }

        [TestMethod]
        public void Test_WithInvalidValue_BiggerThanDouble()
        {
            string[] input = new string[] { "68.7831111111111111111111111111", ValidInput };
            var inputProvider = new ConsoleInputProviderMock(input);
            Assert.AreNotEqual(68.7831111111111111111111111111, inputProvider.GetFieldSize());
        }
    }
}
