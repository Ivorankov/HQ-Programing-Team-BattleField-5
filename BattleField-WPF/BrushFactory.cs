namespace BattleField_WPF
{
    using System.Collections.Generic;

    public class BrushFactory
    {
        private Dictionary<int, IItem> collection = new Dictionary<int, IItem>();

        public void Save(int index, IItem cell)
        {
            this.collection.Add(index, cell);
        }

        public IItem Get(int index)
        {
            return this.collection[index];
        }
    }
}
