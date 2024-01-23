using System;
using System.Drawing;

public class GiaoVienOb
{
    public string MaGiaoVien { get; set; }
    public string TenGiaoVien { get; set; }
    public string MonHoc { get; set; }
    public DateTime NgaySinh { get; set; }
    public Image AnhGiaoVien { get; set; }

    public GiaoVienOb(string MaGV, string tenGiaoVien, string monHoc, DateTime ngaySinh, Image anhGiaoVien)
    {
        MaGiaoVien = MaGV;
        TenGiaoVien = tenGiaoVien;
        MonHoc = monHoc;
        NgaySinh = ngaySinh;
        AnhGiaoVien = anhGiaoVien;
    }
}
