namespace SRS5
{
    abstract public class DomainObject
    {
        int _id;
        public int GetId()
        {
            return _id;
        }
        public void SetID(int _id)
        { 
            this._id = _id; 
        }
        public DomainObject()
        {
            _id = 0;
            Console.WriteLine($"Log: Создаём объект: {this.GetType().Name}");
        }
        protected abstract void LoadObject(List<string> _params);
        public DomainObject(List<string> _params)
        {
            _id = Convert.ToInt32(_params[0]);
            LoadObject(_params);
        }
        public abstract string GetColumns();
        public abstract string GetUpdateColumns();
    }
}