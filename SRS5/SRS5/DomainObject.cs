namespace SRS5
{
    abstract public class DomainObject
    {
        int Id;
        public int GetId() // Получение идентификатора
        {
            return Id;
        }
        public void SetID(int id) // Изменение идентификатора
        { 
            this.Id = id; 
        }
        public DomainObject() { }
        protected abstract void LoadObject(List<string> _params); // Абстрактный метод для загрузки объектов,
                                                                  // который должны будут реализовать все наследники

        public DomainObject(List<string> _params)
        {
            Id = Convert.ToInt32(_params[0]);
            LoadObject(_params);
        }
        public abstract string GetColumns(); // Абстрактный метод для получения полей класса для INSERT-запроса,
                                             // который должны будут реализовать все наследники
        public abstract string GetUpdateColumns(); // Абстрактный метод для получения полей класса для UPDATE-запроса,
                                                   // который должны будут реализовать все наследники
    }
}