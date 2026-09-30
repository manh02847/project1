# Lesson12 - Nguyễn Ngọc Mạnh - 2410900051

ASP.NET Core MVC .NET 8, Entity Framework Core 8 và SQL Server.

## Chạy bài

1. Mở `NnmLesson12EFCore.sln` bằng Visual Studio 2022.
2. Sửa tên SQL Server trong hai chuỗi kết nối ở `appsettings.json` cho đúng máy. Mặc định dùng `.\SQL2019` và Windows Authentication.
3. Trong terminal tại thư mục project, chạy:

```powershell
dotnet tool restore
dotnet ef database update --context NnmAppDbContext
dotnet ef database update --context NnmStudentDbContext
dotnet run --launch-profile http
```

Hai lệnh update tạo CSDL `NnmNetCoreCRUD` và `NnmStudentManager`, gồm cả dữ liệu mẫu. Truy cập `http://localhost:5212`.

Có thể chạy hai script trong `Database` bằng SSMS thay cho hai lệnh update. Script có kiểm tra migration đã chạy nên có thể chạy lại. Không cần chạy cả hai cách.

## Nội dung bài

- Code-First: Category, Product, DbContext, kiểu dữ liệu bằng Column và migration.
- CRUD danh mục; ngày tạo được gán trong controller.
- Bài 1: CRUD sản phẩm có upload ảnh, chọn danh mục.
- Bài 2: action `Product` của `NnmHomeController` hiển thị sản phẩm dạng lưới.
- Bài 3: CRUD banner có upload ảnh.
- Bài 4: banner hoạt động hiển thị trên trang chủ.
- Bài 5: CSDL StudentManager gồm lớp học, sinh viên, môn học và điểm; bảng điểm có khóa chính ghép mã môn học + mã sinh viên.
- Bài 6: CRUD cả bốn bảng, kiểm tra trường bắt buộc, độ dài, email, điện thoại, ngày sinh, khóa ngoại, điểm 0-10 và dữ liệu trùng.

Tên model, bảng và thuộc tính dùng tiền tố `Nnm` giống các lesson trước. Phần DB-First đã thực hiện trong `NnmLesson10EFDbFirst`; lab này triển khai phần Code-First và các bài tự làm.

Ảnh upload lưu tại `wwwroot/Product`, `wwwroot/Banner`, `wwwroot/Student`. Hỗ trợ JPG, JPEG, PNG, GIF, WEBP tối đa 5 MB; khi sửa không chọn ảnh mới sẽ giữ ảnh cũ. Ngày tạo không nhập trên form. Các bản ghi có dữ liệu liên quan cần xóa hoặc chuyển dữ liệu con trước khi xóa.

Dữ liệu mẫu chỉ dùng để thực hành, gồm sinh viên Nguyễn Văn A và điểm mẫu. Thông tin người làm bài nằm trong trang Thông tin.
