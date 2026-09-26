# NguyenNgocManh2410900051_exam

Bài kiểm tra ASP.NET Core MVC của Nguyễn Ngọc Mạnh (MSSV `2410900051`, lớp CNTT K24-CNT2).

## Chức năng

- `Home/HvtAbout`: trang thông tin sinh viên, có liên kết trên Layout.
- `NguyenNgocManhStudents`: CRUD được tạo bằng ASP.NET Core scaffolding với Entity Framework Core và SQL Server.
- Giao diện Bootstrap tiếng Việt, có tìm kiếm, validation ngày sinh, email và số điện thoại.
- `NguyenNgocManhEmployee` giữ cấu trúc bảy cột của phần CSDL trong đề.

## Chạy project

1. Mở file `NguyenNgocManh Employee_2410900051_Db.sql` bằng SQL Server Management Studio và chạy toàn bộ script.
2. Nếu thông tin SQL Server khác, sửa `ConnectionStrings:DefaultConnection` trong `NguyenNgocManh2410900051_exam/appsettings.json`. Mặc định đang dùng SQL Server tại `localhost`, tài khoản `sa`, mật khẩu mẫu `Exam!2410900051`.
3. Mở file `.csproj` bằng Visual Studio, chạy Restore rồi nhấn Start, hoặc dùng `dotnet run` với .NET 8 SDK.

Project được tạo từ template `mvc`; controller và các view CRUD được sinh bởi `dotnet-aspnet-codegenerator`.
