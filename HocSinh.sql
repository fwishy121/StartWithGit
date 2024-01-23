CREATE TABLE HocSinh
(
    MaHocSinh INT PRIMARY KEY IDENTITY(1,1), -- Auto-incremented primary key
    TenHocSinh NVARCHAR(100) NOT NULL,      -- Name of the student
    NgaySinh DATE,                          -- Date of birth
    GioiTinh NVARCHAR(10),                  -- Gender
    DiaChi NVARCHAR(255),                   -- Address
    MaLop INT,                              -- Foreign key to a Class table (if you have one)
    AnhDaiDien VARBINARY(MAX),              -- Profile picture, stored as binary data

    -- Add more fields as required

    CONSTRAINT FK_HocSinh_Lop FOREIGN KEY (MaLop) REFERENCES Lop(MaLop) -- Assuming you have a Lop table for class
    -- Include more constraints or indices as required
);


--thêm dữ liệu
INSERT INTO HocSinh (MaHocSinh, TenHocSinh, NgaySinh, GioiTinh, DiaChi, MaLop, AnhDaiDien)
VALUES
    (1, 'Nguyen Van A', '2005-09-01', 'Nam', '123 Le Loi, Quan 1, TP.HCM', 101, NULL),  
    (2, 'Tran Thi B', '2006-05-15', 'Nu', '456 Ly Thuong Kiet, Quan 3, TP.HCM', 102, NULL); 
