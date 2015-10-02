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
        // Yes this is the drawback the engine has to be passed to this class for it to interact with it
        private Engine engine;

        public WpfInputProvider(Engine engine)
        {
            this.engine = engine;
        }
        public int GetFieldSize()// Obsolete will be removed
        {
            throw new NotImplementedException();
        }

        //This is a subscriber method that is called when event is triggered
        public void GetPosition(object source, EventArgs args)
        {
            var cell =  source as Cell;
            this.engine.UpdateField(cell.Pos);
        }

        public delegate void UserInputPositionHandler(object source, EventArgs args);

        public event UserInputPositionHandler CellClicked;

        //Publisher method, when called notifyes subs
        public void TakeCellCoordinates(object source, EventArgs args)
        {
            this.OnCellClick(source, args);
        }

        public string GetPlayerName()//Obsolete will be removed
        {
            throw new NotImplementedException();
        }

        //Used to publish the event
        protected virtual void OnCellClick(object source, EventArgs args)
        {
            if (CellClicked != null)
            {
                CellClicked(source, args);
            }
        }
    }
}
