using Microsoft.Data.SqlClient;

namespace SRS5
{
    internal class DBConnection
    {
        private SqlConnection Connection;
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
                Console.WriteLine(Connection.State);
                var reader = sqlCommand.ExecuteReader();
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
            return new List<string>();
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