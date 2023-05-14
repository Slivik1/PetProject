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
                Connection = new DBConnection($@"Data Source = DESKTOP-4AM24DD\MSSQLSERVER01; Initial Catalog = OOP; Integrated Security = true; TrustServerCertificate=True");
            }
        }
        public DomainObject Find(int id)
        {
            return SelectStmt(id);
        }
        protected DomainObject SelectStmt(int id)
        {
            string query = $"SELECT * FROM {TableName} WHERE id = {id}";
            List<string> Data = Connection.SelectQuery(query);
            return GetObj(TableName, Data);
        }
        public void Save(DomainObject domainObject, int id)
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
        public void Delete(int id) 
        {
            if (Find(id) != null) 
            {
                string query = $"DELETE FROM {TableName} WHERE id = {id}";
                Connection.DeleteQuery(query);
            }
        }
        protected DomainObject GetObj(string _tableName, List<string> _params)
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
                return domainObject;
            }

        }
    }
}