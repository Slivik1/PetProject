using Microsoft.Data.SqlClient;

namespace SRS5
{
    internal class DBConnection //Класс, реализующий подключение к базе данных
    {
        private SqlConnection Connection;
        List<string> Data = new List<string>();
        List<int> IntValues = new List<int>();
        public DBConnection(string DMS)
        {
            Connection = new SqlConnection(DMS);
            Console.WriteLine($"Log: Подключение к {DMS} установлено!");
        }
        public List<string> SelectQuery(string query) // SELECT-запрос к базе данных c последующим чтением ответа 
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
                            var value = reader.GetValue(i);
                            Data.Add(Convert.ToString(value));
                        }
                    }
                }
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
            return Data;
        }
        public void InsertQuery(string query) // INSERT-запрос к базе данных
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
        public void UpdateQuery(string query) // UPDATE-запрос к базе данных
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
        public void DeleteQuery(string query) // DELETE-запрос к базе данных
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