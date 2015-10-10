namespace MineFieldAppTests
{
    using System.Collections.Generic;
    using MineFieldApp;

    public class ConsoleInputProviderMock : ConsoleInputProvider
    {
        private IEnumerator<string> iterator;

        public ConsoleInputProviderMock(IEnumerable<string> input)
        {
            this.iterator = input.GetEnumerator();
        }

        protected override string GetUserInput()
        {
            this.iterator.MoveNext();
            return this.iterator.Current;
        }
    }
}
