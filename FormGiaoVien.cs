using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowForm
{
    public partial class FormGiaoVien : Form
    {
        private DataGridView dataGridView1;
        private TextBox txtHoTen;
        private TextBox txtMonHoc;
        private DateTimePicker dtpNgaySinh;
        private Button btnChonAnh;
        private PictureBox pictureBox1;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;

        private string connectionString = "Data Source=DESKTOP-C72O0SO\\FISHY;Initial Catalog=QuanLySinhVien;User ID=ca;Password=123";

        private GiaoVienDAO giaoVienDAO;
        private GiaoVienOb giaoVienOb;
        public FormGiaoVien()
        {
            InitializeComponent();
            giaoVienDAO = new GiaoVienDAO(connectionString);
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Tạo DataGridView để hiển thị dữ liệu
            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(500, 20);
            dataGridView1.Size = new Size(600, 600);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellClick += DataGridView1_CellClick;
            this.Controls.Add(dataGridView1);

            // Tạo các cột cho DataGridView
            DataGridViewTextBoxColumn maGVColumn = new DataGridViewTextBoxColumn();
            maGVColumn.DataPropertyName = "MaGV";
            maGVColumn.HeaderText = "Mã GV";
            dataGridView1.Columns.Add(maGVColumn);

            DataGridViewTextBoxColumn tenGVColumn = new DataGridViewTextBoxColumn();
            tenGVColumn.DataPropertyName = "TenGV";
            tenGVColumn.HeaderText = "Tên GV";
            dataGridView1.Columns.Add(tenGVColumn);

            DataGridViewTextBoxColumn monHocColumn = new DataGridViewTextBoxColumn();
            monHocColumn.DataPropertyName = "MonHoc";
            monHocColumn.HeaderText = "Môn học";
            dataGridView1.Columns.Add(monHocColumn);

            DataGridViewTextBoxColumn ngaySinhColumn = new DataGridViewTextBoxColumn();
            ngaySinhColumn.DataPropertyName = "NgaySinh";
            ngaySinhColumn.HeaderText = "Ngày sinh";
            dataGridView1.Columns.Add(ngaySinhColumn);

            DataGridViewImageColumn anhColumn = new DataGridViewImageColumn();
            anhColumn.DataPropertyName = "Anh";
            anhColumn.HeaderText = "Ảnh";
            dataGridView1.Columns.Add(anhColumn);


            // Controls để điền thông tin giáo viên
            txtHoTen = new TextBox();
            txtHoTen.Text = "Họ tên giáo viên";
            txtHoTen.Location = new Point(20, 250);
            this.Controls.Add(txtHoTen);

            //môn học
            txtMonHoc = new TextBox();
            txtMonHoc.Text = "Môn học";
            txtMonHoc.Location = new Point(20, 280);
            this.Controls.Add(txtMonHoc);


            dtpNgaySinh = new DateTimePicker();
            dtpNgaySinh.Location = new Point(20, 310);
            this.Controls.Add(dtpNgaySinh);

            btnChonAnh = new Button();
            btnChonAnh.Text = "Chọn Ảnh";
            btnChonAnh.Location = new Point(20, 340);
            btnChonAnh.Click += BtnChonAnh_Click;
            this.Controls.Add(btnChonAnh);

            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(120, 340);
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pictureBox1);

            btnThem = new Button();
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(20, 470);
            btnThem.Click += BtnThem_Click;
            this.Controls.Add(btnThem);

            btnXoa = new Button();
            btnXoa.Text = "Xoá";
            btnXoa.Location = new Point(120, 470);
            btnXoa.Click += BtnXoa_Click;
            this.Controls.Add(btnXoa);

            btnSua = new Button();
            btnSua.Text = "Sửa";
            btnSua.Location = new Point(220, 470);
            btnSua.Click += BtnSua_Click;
            this.Controls.Add(btnSua);

            // Ẩn phần controls để nhập thông tin giáo viên (nếu bạn muốn)
            RefreshDataGridView();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                FillInputFieldsFromSelectedRow(selectedRow);
            }
        }

        private void FillInputFieldsFromSelectedRow(DataGridViewRow row)
        {
            // Lấy dữ liệu từ dòng được chọn trong DataGridView và điền vào các controls
            txtHoTen.Text = row.Cells[1].Value.ToString();
            txtMonHoc.Text = row.Cells[2].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            pictureBox1.Image = ImageFromByteArray((byte[])row.Cells[4].Value);
        }

        private Image ImageFromByteArray(byte[] byteArray)
        {
            // Chuyển đổi mảng byte sang hình ảnh
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                return Image.FromStream(memoryStream);
            }
        }


        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            AddGiaoVien();
            RefreshDataGridView();
            ClearInputFields();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {

            DeleteGiaoVien();
            RefreshDataGridView();
            ClearInputFields();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            EditGiaoVien();
            RefreshDataGridView();
            ClearInputFields();
        }

        // private void AddGiaoVien()
        // {
        //     GiaoVienOb gv = new GiaoVienOb()
        //     {



        //     }
        //     giaoVienDAO.AddGiaoVien(giaoVienOb);
        // }

        // private void AddGiaoVien()
        // {
        //     GiaoVienOb giaoVienOb = new GiaoVienOb(
        //         null,
        //         txtHoTen.Text,
        //         txtMonHoc.Text,
        //         dtpNgaySinh.Value,
        //         pictureBox1.Image
        //     );

        //     giaoVienDAO.AddGiaoVien(giaoVienOb);
        // }

        private void AddGiaoVien()
        {
            Image image = pictureBox1.Image;
            // Bạn chỉ chuyển đổi hình ảnh sang byte[] khi cần lưu vào cơ sở dữ liệu.
            // Khi khởi tạo đối tượng GiaoVienOb, bạn vẫn sử dụng kiểu Image.
            GiaoVienOb giaoVienOb = new GiaoVienOb(
                GenerateMaGV(),
                txtHoTen.Text,
                txtMonHoc.Text,
                dtpNgaySinh.Value,
                image  // Không chuyển đổi ở đây, giữ nguyên là Image
            );

            giaoVienDAO.AddGiaoVien(giaoVienOb);
        }
        
        private void DeleteGiaoVien()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maGV = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                giaoVienDAO.DeleteGiaoVien(maGV);
            }
        }

        private void EditGiaoVien()
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (dataGridView1.SelectedRows.Count > 0)
            {
                GiaoVienOb giaoVienOb = new GiaoVienOb(
                    selectedRow.Cells[0].Value.ToString(),
                    txtHoTen.Text,
                    txtMonHoc.Text,
                    dtpNgaySinh.Value,
                    pictureBox1.Image
                );

                giaoVienDAO.EditGiaoVien(giaoVienOb);
            }
        }
        public void SetDataSource(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dataGridView1.DataSource = dataTable;

            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputFields()
        {
            txtHoTen.Text = "";
            txtMonHoc.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            pictureBox1.Image = null;
        }

        private void ShowInputControls()
        {
            txtHoTen.Visible = true;
            txtMonHoc.Visible = true;
            dtpNgaySinh.Visible = true;
            btnChonAnh.Visible = true;
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

        private void RefreshDataGridView()
        {
            DataTable newData = GetGiaoVienData();
            SetDataSource(newData);
        }

        private DataTable GetGiaoVienData()
        {
            DataTable dataTable = new DataTable();
            MessageBox.Show("DEbug.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM GiaoVien";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                MessageBox.Show("SELECT * FROM GiaoVien." + dataTable.Rows.Count, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connection.Close();
            }

            return dataTable;
        }

    }
}
