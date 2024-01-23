namespace WindowForm;

public partial class Form1 : Form
{
    private TextBox txtHoTen;
    private RadioButton rbtnNam;
    private RadioButton rbtnNu;
    private DateTimePicker dtpNgaySinh;
    private PictureBox pictureBox1;
    private Button btnChonAnh;
    public Form1()
    {
        InitializeComponent();
        InitializeControls();
    }

    private void InitializeControls()
    {
        // Họ tên
        Label lblHoTen = new Label();
        lblHoTen.Text = "Họ Tên:";
        lblHoTen.Location = new Point(20, 20);
        this.Controls.Add(lblHoTen);

        txtHoTen = new TextBox();
        txtHoTen.Location = new Point(120, 20);
        this.Controls.Add(txtHoTen);

        // Giới tính
        Label lblGioiTinh = new Label();
        lblGioiTinh.Text = "Giới Tính:";
        lblGioiTinh.Location = new Point(20, 60);
        this.Controls.Add(lblGioiTinh);

        rbtnNam = new RadioButton();
        rbtnNam.Text = "Nam";
        rbtnNam.Location = new Point(120, 60);
        this.Controls.Add(rbtnNam);

        rbtnNu = new RadioButton();
        rbtnNu.Text = "Nữ";
        rbtnNu.Location = new Point(250, 60);
        this.Controls.Add(rbtnNu);

        // Ngày tháng năm sinh
        Label lblNgaySinh = new Label();
        lblNgaySinh.Text = "Ngày Sinh:";
        lblNgaySinh.Location = new Point(20, 100);
        this.Controls.Add(lblNgaySinh);

        dtpNgaySinh = new DateTimePicker();
        dtpNgaySinh.Location = new Point(120, 100);
        this.Controls.Add(dtpNgaySinh);

        // Ảnh
        Label lblAnh = new Label();
        lblAnh.Text = "Ảnh:";
        lblAnh.Location = new Point(20, 140);
        this.Controls.Add(lblAnh);

        pictureBox1 = new PictureBox();
        pictureBox1.Location = new Point(120, 140);
        pictureBox1.Size = new Size(100, 100);
        pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        this.Controls.Add(pictureBox1);

        btnChonAnh = new Button();
        btnChonAnh.Text = "Chọn Ảnh";
        btnChonAnh.Location = new Point(230, 140);
        btnChonAnh.Click += BtnChonAnh_Click;
        this.Controls.Add(btnChonAnh);

        void BtnChonAnh_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
