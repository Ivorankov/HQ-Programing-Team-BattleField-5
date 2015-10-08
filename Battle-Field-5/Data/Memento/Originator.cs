namespace MineFieldApp.Data.Memento
{
    public class Originator
    {
        //Orig... why am I naming them

        public GameObjData GameObject { get; private set; }

        public void Set(GameObjData gameObject)
        {
            this.GameObject = gameObject;
        }

        public GameObjMemento StoreInMemento()
        {
            return new GameObjMemento(this.GameObject);
        }

        public GameObjData RestoreDataFromMemento(GameObjMemento memento)
        {
            return this.GameObject = memento.GetDataObject();
        }
    }
}
