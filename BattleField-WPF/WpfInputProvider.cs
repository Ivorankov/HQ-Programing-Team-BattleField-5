using BattleField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField_WPF
{
    public class WpfInputProvider 
    {
        private Engine engine;
        public WpfInputProvider(Engine engine)
        {
            this.engine = engine;
        }
        public int GetFieldSize()
        {
            throw new NotImplementedException();
        }

        public void GetPosition(object source, EventArgs args)
        {
            var cell =  source as Cell;
            this.engine.UpdateField(cell.Pos);
        }

        public delegate void UserInputPositionHandler(object source, EventArgs args);

        public event UserInputPositionHandler position;

        public void Trigger(object source, EventArgs args)
        {
            this.OnCellClick(source, args);
        }

        public string GetPlayerName()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnCellClick(object source, EventArgs args)
        {
            if (position != null)
            {
                position(source, args);
            }
        }
    }
}
