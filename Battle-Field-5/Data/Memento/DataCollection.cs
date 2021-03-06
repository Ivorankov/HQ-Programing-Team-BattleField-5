﻿namespace MineFieldApp.Data
{
    using System.Collections.Generic;

    public class DataCollection
    {
        //Caretaker
        public List<GameObjMemento> GameObjectCollecton { get; private set; }

        public void AddMementoObject(GameObjMemento gameObject)
        {
            this.GameObjectCollecton.Add(gameObject);
        }

        public GameObjMemento GetMementoObject(int index)
        {
            return this.GameObjectCollecton[index];
        }
    }
}
