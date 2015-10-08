namespace MineFieldAppTests
{
    using MineFieldApp;
    using System.Collections.Generic;

    public class ConsoleInputProviderMock : ConsoleInputProvider
    {
        private IEnumerator<string> iterator;

        public ConsoleInputProviderMock(IEnumerable<string> input) {
            this.iterator = input.GetEnumerator();
        }

        protected override string GetUserInput()
        {
            iterator.MoveNext();
            return iterator.Current;
        }
    }
}
