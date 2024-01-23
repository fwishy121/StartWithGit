using System.Data;
using System.Data.SqlClient;

namespace WindowForm
{
    public class BaseDao
    {
        protected readonly string connectionString;

        public BaseDao(string connectionString)
        {
            this.connectionString = "Data Source=DESKTOP-C72O0SO\\FISHY;Initial Catalog=QuanLySinhVien;User ID=ca;Password=123";
        }

        protected DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                connection.Close();
            }
            return dataTable;
        }

        protected void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
