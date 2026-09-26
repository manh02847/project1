using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenNgocManh2410900051.Models;

[Table("NguyenNgocManhStudent")]
public class NguyenNgocManhStudent : IValidatableObject
{
    [Key]
    [Display(Name = "Mã")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
    [StringLength(100, ErrorMessage = "Họ tên không quá 100 ký tự.")]
    [Display(Name = "Họ và tên")]
    public string NguyenNgocManhName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
    [RegularExpression("^(Nam|Nữ|Khác)$", ErrorMessage = "Giới tính không hợp lệ.")]
    [StringLength(10)]
    [Display(Name = "Giới tính")]
    public string NguyenNgocManhGender { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
    [Column(TypeName = "date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Display(Name = "Ngày sinh")]
    public DateTime? NguyenNgocManhBirthDay { get; set; }

    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [StringLength(150, ErrorMessage = "Email không quá 150 ký tự.")]
    [Display(Name = "Email")]
    public string? NguyenNgocManhEmail { get; set; }

    [RegularExpression(@"^\+?[0-9]{9,15}$", ErrorMessage = "Số điện thoại gồm 9–15 chữ số, có thể bắt đầu bằng +.")]
    [StringLength(20)]
    [Column(TypeName = "varchar(20)")]
    [Display(Name = "Số điện thoại")]
    public string? NguyenNgocManhPhone { get; set; }

    [Display(Name = "Đang hoạt động")]
    public bool NguyenNgocManhActive { get; set; } = true;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (NguyenNgocManhBirthDay.HasValue &&
            (NguyenNgocManhBirthDay.Value.Date > DateTime.Today || NguyenNgocManhBirthDay.Value.Year < 1900))
        {
            yield return new ValidationResult("Ngày sinh phải từ năm 1900 đến hôm nay.",
                new[] { nameof(NguyenNgocManhBirthDay) });
        }
    }
}
