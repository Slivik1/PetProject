namespace SRS5
{
    internal class CamelCase
    {
        static DomainObject? domainObject;
        public static DomainObject GetClassName(string _tableName)
        {
            string _myClassName;
            if (_tableName == "Triangle")
            {
                domainObject = new Triangle();
            }
            else
            {
                domainObject = new triangle_type();
            }
            return domainObject;
        }
    }
}