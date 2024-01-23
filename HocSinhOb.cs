using System;
using System.Drawing;

public class HocSinhOb
{
    // Properties of a student (Adjust these according to your actual database structure)
    public string MaHocSinh { get; set; }
    public string TenHocSinh { get; set; }
    public DateTime NgaySinh { get; set; }
    public Image AnhHocSinh { get; set; }

    // Constructor to initialize a student object
    public HocSinhOb(string maHocSinh, string tenHocSinh, DateTime ngaySinh, Image anhHocSinh)
    {
        MaHocSinh = maHocSinh;
        TenHocSinh = tenHocSinh;
        NgaySinh = ngaySinh;
        AnhHocSinh = anhHocSinh;
    }
}
