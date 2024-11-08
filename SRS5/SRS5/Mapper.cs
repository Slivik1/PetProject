using System.Reflection;
namespace SRS5
{
    class Mapper
    {
        protected static DBConnection Connection = null;
        public string TableName;
        public Mapper(string TableName) 
        {
            this.TableName = TableName;
            if (Connection == null) 
            {
                Connection = new DBConnection($@"Data Source = SLIVIK; Initial Catalog = TrianglesMad; 
                                              Integrated Security = true; TrustServerCertificate=True");
            }
        }
        public DomainObject Find(int id) // Метод, возвращающий результат вывода метода SelectStmt.
                                         // В результате будет выдан объект из словаря, если он существует
        {
            return SelectStmt(id);
        }
        protected DomainObject SelectStmt(int id)  // Метод, возвращающий результат вывода метода GetObj 
        {
            string query = $"SELECT * FROM {TableName} WHERE id = {id}";
            List<string> Data = Connection.SelectQuery(query);
            return GetObj(TableName, Data);
        }
        public void Save(DomainObject domainObject, int id) // Метод, создающий UPDATE-запрос к базе данных, если заданный объект существует,
                                                            // в противном случае создается INSERT-запрос
                                                            // После передает запрос в класс DBConnection
        {
            if (Find(id) == null)
            {
                string query = $"INSERT INTO {TableName} VALUES ({domainObject.GetColumns()})";
                Connection.InsertQuery(query);
            }
            else
            {
                string query = $"UPDATE {TableName} SET {domainObject.GetUpdateColumns()} WHERE id = {domainObject.GetId()};";
                Connection.UpdateQuery(query);
            }
        }
        public void Delete(int id) // Метод, создающий DELETE-запрос к базе данных, если заданный объект существует
                                   // После передает запрос в класс DBConnection
        {
            if (Find(id) != null) 
            {
                string query = $"DELETE FROM {TableName} WHERE id = {id}";
                Connection.DeleteQuery(query);
            }
        }
        protected DomainObject GetObj(string _tableName, List<string> _params) // Метод, обращающийся к словарю за поиском заданного объекта
        {
            ObjectWatcher objectWatcher = ObjectWatcher.GetInstance();
            if (_params.Count == 0)
            {
                Console.WriteLine("Объект не найден!");
                return null;
            }
            else
            {
                DomainObject _myClassName = CamelCase.GetClassName(_tableName, _params);
                var classType = _myClassName.GetType();
                ConstructorInfo? ci = classType.GetConstructor(new Type[] { typeof(List<string>) });
                DomainObject domainObject = (DomainObject)ci.Invoke(new object[] { _params });
                objectWatcher.Add($"{_params[0]}", domainObject);
                objectWatcher.GetObject($"{_params[0]}");
                _params.Clear();
                return domainObject;
            }

        }
    }
}