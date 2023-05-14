namespace SRS5
{
    // Класс типов треугольников. Полное отображение таблицы TriangleType из базы данных.
    public class TriangleType : DomainObject
    {
        public string NameType;
        public string TypeDescription;
        public TriangleType() : base() { }
        public TriangleType(List<string> _params) : base(_params) { }
        protected override void LoadObject(List<string> _params)
        {
            NameType = Convert.ToString(_params[1]);
            TypeDescription = Convert.ToString(_params[2]);
        }
        //Получение значений полей класса для INSERT запроса
        public override string GetColumns()
        {
            return $"{GetId()}, '{NameType}', '{TypeDescription}'";
        }
        //Получение значений полей класса для UPDATE запроса
        public override string GetUpdateColumns()
        {
            return $"NameType = '{NameType}', TypeDescription = '{TypeDescription}'";
        }
    }
}