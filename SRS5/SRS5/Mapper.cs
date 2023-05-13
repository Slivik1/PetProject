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
            Data = SelectRes(id);
            return GetObj(TableName, Data);
        }
        public void Save(DomainObject domainObject)
        {
            if (Find(domainObject.GetId()) != null)
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
            DomainObject domainObject = objectWatcher.GetObject($"{_tableName}_{_params[0]}");
            if (domainObject == null) 
            {
                DomainObject _myClassName = CamelCase.GetClassName(_tableName);
                var t = _myClassName.GetType();
                ConstructorInfo? ci = t.GetConstructor(new Type[] { typeof (List<string>) });
                domainObject =  (DomainObject)ci.Invoke(new object[] { _params });
                objectWatcher.Add($"{_tableName}_{_params[0]}", domainObject);
            }
            return domainObject;

        }
        protected List<string> SelectRes(int id)
        {
            if (TableName == "triangle_type")
            {
                return new List<string> { Convert.ToString(id), "Прямоугольный треугольник", "Имеет угол 90 градусов" };
            }
            else
            {
                return new List<string> { Convert.ToString(id), "2" , "12", "1" };
            }
        }
    }
}