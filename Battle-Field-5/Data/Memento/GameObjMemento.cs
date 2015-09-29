using System;

namespace BattleField.Data
{
    public class GameObjMemento
    {
        //Memento, not that the stupid name does'nt give it away...
        public GameObjMemento(GameObjData gameData)
        {
            this.GameData = gameData;
        }

        private GameObjData GameData { get; set; }

        public GameObjData GetDataObject()
        {
            return this.GameData;
        }
    }
}
