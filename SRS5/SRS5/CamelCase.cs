namespace SRS5
{
    
    internal class CamelCase //Класс для получения типа во время выполнения программы
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