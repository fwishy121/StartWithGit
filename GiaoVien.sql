-- tạo bảng giáo viên với các thuộc tính, tên, môn học, ngày sinh, ảnh
CREATE TABLE GiaoVien(
    maGV varchar(10) primary key,
    tenGV nvarchar(50),
    monHoc nvarchar(50),
    ngaySinh date,
    anh varbinary(max)
)

-- thêm các giá trị vào bảng giáo viên
INSERT INTO GiaoVien VALUES('GV001', N'Nguyễn Văn A', N'Toán', '1990-01-01', NULL)
INSERT INTO GiaoVien VALUES('GV002', N'Nguyễn Văn B', N'Văn', '1990-01-01', NULL)
INSERT INTO GiaoVien VALUES('GV003', N'Nguyễn Văn C', N'Anh', '1990-01-01', NULL)
INSERT INTO GiaoVien VALUES('GV004', N'Nguyễn Văn D', N'Vật Lý', '1990-01-01', NULL)
INSERT INTO GiaoVien VALUES('GV005', N'Nguyễn Văn E', N'Hóa', '1990-01-01', NULL)
INSERT INTO GiaoVien VALUES('GV006', N'Nguyễn Văn F', N'Sinh', '1990-01-01', NULL)

--in ra các giá trị trong bảng giáo viên
SELECT * FROM GiaoVien
