namespace SRS5
{

    public class TriangleType : DomainObject // Класс типов треугольников. Полное отображение таблицы TriangleType из базы данных.
    {
        public string NameType;
        public string TypeDescription;
        public TriangleType() : base() { }
        public TriangleType(List<string> _params) : base(_params) { }
        protected override void LoadObject(List<string> _params) // Загрузка объекта(тип треугольника)
        {
            NameType = Convert.ToString(_params[1]);
            TypeDescription = Convert.ToString(_params[2]);
        }
        public override string GetColumns() //Получение значений полей класса для INSERT запроса
        {
            return $"'{NameType}', '{TypeDescription}'";
        }
        public override string GetUpdateColumns() //Получение значений полей класса для UPDATE запроса
        {
            return $"NameType = '{NameType}', TypeDescription = '{TypeDescription}'";
        }
    }
}