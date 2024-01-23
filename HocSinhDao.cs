using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WindowForm
{
    public class HocSinhDAO
    {
        private readonly string connectionString;

        public HocSinhDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Method to get all students
        public DataTable GetHocSinhData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM HocSinh";  // Adjust the query if needed
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                connection.Close();
            }

            return dataTable;
        }

        // Additional methods to Insert, Update, Delete HocSinh can be added here
    }
}
