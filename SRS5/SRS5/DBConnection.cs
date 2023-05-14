using Microsoft.Data.SqlClient;

namespace SRS5
{
    //Класс реализующий подключение к базе данных
    internal class DBConnection
    {
        private SqlConnection Connection;
        List<string> Data = new List<string>();
        List<int> IntValues = new List<int>();
        public DBConnection(string DMS)
        {
            Connection = new SqlConnection(DMS);
            Console.WriteLine($"Log: Подключение к {DMS} установлено!");
        }
        public List<string> SelectQuery(string query)
        {
            Console.WriteLine($"Log: выполняется select-запрос {query}");
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                var reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var values = reader.GetValue(i);
                            var typeValues = values.GetType();
                            var typeI = i.GetType();
                            if (typeValues.Equals(typeI))
                            {
                                IntValues.Add((int)values);
                                foreach (var intValue in IntValues)
                                {
                                    Data.Add(intValue.ToString());
                                }
                            }
                            else
                            {
                                Data.Add((string)values);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Connection.Close(); 
            return Data;
        }
        public void InsertQuery(string query)
        {
            try
            {
                Console.WriteLine($"Log: выполняется insert-запрос {query}");
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Connection.Close();
        }
        public void UpdateQuery(string query)
        {
            try
            {
                Console.WriteLine($"Log: выполняется update-запрос {query}");
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.Close();
        }
        public void DeleteQuery(string query)
        {

            Console.WriteLine($"Log: выполняется delete-запрос {query}");
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            Connection.Open();
            sqlCommand.ExecuteNonQuery();
            try
            {

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.Close();
        }
    }
}