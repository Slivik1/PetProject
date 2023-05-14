namespace SRS5
{
    //Класс для получения типа во время выполнения программы
    internal class CamelCase
    {
        static DomainObject? domainObject;
        public static DomainObject GetClassName(string _tableName, List<string> _params)
        {
            if (_tableName == "Triangle")
            {
                domainObject = new Triangle(_params);
            }
            else
            {
                domainObject = new TriangleType(_params);
            }
            return domainObject;
        }
    }
}