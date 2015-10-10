using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField_WPF
{
    class BrushFactory
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
