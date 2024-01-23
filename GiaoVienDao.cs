using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WindowForm
{
    public class GiaoVienDAO : BaseDao
    {
        public GiaoVienDAO(string connectionString) : base(connectionString) { }

        public DataTable GetGiaoVienData()
        {
            string query = "SELECT * FROM GiaoVien";
            return ExecuteQuery(query);
        }

        // public void AddGiaoVien(GiaoVienOb gv)
        // {
        //     string query = "INSERT INTO GiaoVien (maGV, tenGV, monHoc, ngaySinh, anh) " +
        //                    "VALUES (@maGV, @tenGV, @monHoc, @ngaySinh, @anh)";

        //     SqlParameter[] parameters =
        //     {
        //         new SqlParameter("@maGV", GenerateMaGV()),
        //         new SqlParameter("@tenGV", gv.TenGiaoVien),
        //         new SqlParameter("@monHoc", gv.MonHoc),
        //         new SqlParameter("@ngaySinh", gv.NgaySinh),
        //         new SqlParameter("@anh", ImageToByteArray(gv.AnhGiaoVien))
        //     };

        //     ExecuteNonQuery(query, parameters);
        // }

        public void AddGiaoVien(GiaoVienOb gv)
        {
            if (gv.MaGiaoVien == null)
            {
                gv.MaGiaoVien = GenerateMaGV();
            }

            string query = "INSERT INTO GiaoVien (maGV, tenGV, monHoc, ngaySinh, anh) " +
                           "VALUES (@maGV, @tenGV, @monHoc, @ngaySinh, @anh)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@maGV", gv.MaGiaoVien),
                new SqlParameter("@tenGV", gv.TenGiaoVien),
                new SqlParameter("@monHoc", gv.MonHoc),
                new SqlParameter("@ngaySinh", gv.NgaySinh),
                new SqlParameter("@anh", gv.AnhGiaoVien != null ? ImageToByteArray(gv.AnhGiaoVien) : DBNull.Value)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void DeleteGiaoVien(string maGV)
        {
            string query = "DELETE FROM GiaoVien WHERE maGV = @maGV";
            SqlParameter[] parameters = { new SqlParameter("@maGV", maGV) };
            ExecuteNonQuery(query, parameters);
        }

        // public void EditGiaoVien(string maGV, GiaoVienOb gv)
        // {
        //     string query = "UPDATE GiaoVien " +
        //                    "SET tenGV = @tenGV, monHoc = @monHoc, ngaySinh = @ngaySinh, anh = @anh " +
        //                    "WHERE maGV = @maGV";

        //     SqlParameter[] parameters =
        //     {
        //         new SqlParameter("@maGV", maGV),
        //         new SqlParameter("@tenGV", gv.TenGiaoVien),
        //         new SqlParameter("@monHoc", gv.MonHoc),
        //         new SqlParameter("@ngaySinh", gv.NgaySinh),
        //         new SqlParameter("@anh", ImageToByteArray(gv.AnhGiaoVien))
        //     };

        //     ExecuteNonQuery(query, parameters);
        // }

        public void EditGiaoVien(GiaoVienOb gv)
        {
            string query = "UPDATE GiaoVien " +
                           "SET tenGV = @tenGV, monHoc = @monHoc, ngaySinh = @ngaySinh, anh = @anh " +
                           "WHERE maGV = @maGV";

            SqlParameter[] parameters =
            {
                new SqlParameter("@maGV", gv.MaGiaoVien), 
                new SqlParameter("@tenGV", gv.TenGiaoVien),
                new SqlParameter("@monHoc", gv.MonHoc),
                new SqlParameter("@ngaySinh", gv.NgaySinh),
                new SqlParameter("@anh", gv.AnhGiaoVien != null ? ImageToByteArray(gv.AnhGiaoVien) : DBNull.Value)
            };

            ExecuteNonQuery(query, parameters);
        }


        private string GenerateMaGV()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }

        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            return memoryStream.ToArray();
        }
    }
}
