namespace SRS5
{
    abstract public class DomainObject
    {
        int Id;
        public int GetId()
        {
            return Id;
        }
        public void SetID(int id)
        { 
            this.Id = id; 
        }
        public DomainObject()
        {

        }
        protected abstract void LoadObject(List<string> _params);
        public DomainObject(List<string> _params)
        {
            Id = Convert.ToInt32(_params[0]);
            LoadObject(_params);
        }
        public abstract string GetColumns();
        public abstract string GetUpdateColumns();
    }
}