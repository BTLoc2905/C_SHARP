# 🎓 Quản Lý Sinh Viên - C# WinForms (Mô hình 3 lớp)

Đây là dự án phần mềm Quản lý sinh viên trên nền tảng desktop (Windows Forms), được xây dựng bằng ngôn ngữ **C#** và áp dụng kiến trúc **Mô hình 3 lớp (3-Tier Architecture)** kết hợp với cơ sở dữ liệu **SQL Server**. 

Dự án nằm trong học phần/bài tập thực hành của Khoa Công nghệ thông tin - Đại học Sài Gòn (SGU).

## 🚀 Chức năng chính
- Hiển thị danh sách sinh viên lên DataGridView.
- **Thêm** sinh viên mới vào CSDL.
- **Sửa** thông tin (Họ, Tên) của sinh viên theo Mã.
- **Xóa** sinh viên khỏi hệ thống.
- **Tìm kiếm** sinh viên theo Mã hoặc Họ Tên.
- Reset/Làm mới giao diện nhập liệu.

## 🛠 Công nghệ & Thư viện sử dụng
- **Ngôn ngữ:** C# (.NET 10.0)
- **Giao diện:** Windows Forms (Code giao diện thuần, không dùng kéo thả)
- **Cơ sở dữ liệu:** SQL Server (Localhost)
- **Thư viện kết nối CSDL:** `Microsoft.Data.SqlClient`

## 📁 Cấu trúc thư mục (Mô hình 3 lớp)
- **DTO (Data Transfer Object):** `SinhVienDTO.cs` - Lưu trữ các thuộc tính của đối tượng Sinh Viên (Mã, Họ, Tên).
- **DAO (Data Access Object):** `SinhVienDAO.cs`, `MyConnect.cs` - Tầng giao tiếp trực tiếp với CSDL SQL Server, thực thi các câu lệnh `SELECT`, `INSERT`, `UPDATE`, `DELETE`.
- **BUS (Business Logic Layer):** `SinhVienBUS.cs` - Tầng xử lý nghiệp vụ, kiểm tra dữ liệu trước khi gọi xuống tầng DAO.
- **GUI (Graphical User Interface):** `Form1.cs` / `SINHVIENGUI.CS` - Tầng giao diện người dùng, tiếp nhận sự kiện click button, nhập textbox...

## ⚙️ Hướng dẫn cài đặt & Chạy dự án

### 1. Chuẩn bị Cơ sở dữ liệu (SQL Server)
Mở SQL Server Management Studio (SSMS) và chạy đoạn script sau để tạo Database và Bảng dữ liệu:

```sql
CREATE DATABASE SinhVien;
GO
USE SinhVien;
GO

CREATE TABLE SINHVIEN (
    MA VARCHAR(20) PRIMARY KEY,
    HO NVARCHAR(50),
    TEN NVARCHAR(50)
);
GO

-- Thêm dữ liệu mẫu
INSERT INTO SINHVIEN VALUES ('SV01', N'Nguyễn Văn', N'A');
INSERT INTO SINHVIEN VALUES ('SV02', N'Trần Thị', N'B');