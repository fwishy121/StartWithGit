using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string connectionString = "Data Source=DESKTOP-C72O0SO\\FISHY;Initial Catalog=QuanLySinhVien;User ID=ca;Password=123";

                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng GiaoVien
                    SqlCommand command = new SqlCommand("SELECT * FROM GiaoVien", connection);

                    // Sử dụng SqlDataAdapter để đổ dữ liệu vào DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    connection.Close();
                }

                // Tạo và hiển thị form FormGiaoVien và truyền dữ liệu
                FormGiaoVien formGiaoVien = new FormGiaoVien();
                formGiaoVien.SetDataSource(dataTable);

                // Hiển thị form
                Application.Run(formGiaoVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
