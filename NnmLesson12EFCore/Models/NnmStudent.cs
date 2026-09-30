using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NnmLesson12EFCore.Models;

[Table("NnmStudent")]
public class NnmStudent
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Họ tên sinh viên")]
    [Required(ErrorMessage = "Họ tên không được để trống")]
    [StringLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
    [Column(TypeName = "nvarchar(100)")]
    public string NnmStudentName { get; set; } = string.Empty;

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    [StringLength(100, ErrorMessage = "Email tối đa 100 ký tự")]
    [Column(TypeName = "nvarchar(100)")]
    public string NnmStudentEmail { get; set; } = string.Empty;

    [Display(Name = "Số điện thoại")]
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại gồm 10 chữ số, bắt đầu bằng 0")]
    [StringLength(50)]
    [Column(TypeName = "nvarchar(50)")]
    public string NnmStudentPhone { get; set; } = string.Empty;

    [Display(Name = "Địa chỉ")]
    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    [StringLength(150, ErrorMessage = "Địa chỉ tối đa 150 ký tự")]
    [Column(TypeName = "nvarchar(150)")]
    public string NnmStudentAddress { get; set; } = string.Empty;

    [Display(Name = "Ảnh đại diện")]
    [Column(TypeName = "nvarchar(100)")]
    [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
    [ValidateNever]
    public string NnmStudentAvatar { get; set; } = string.Empty;

    [Display(Name = "Ngày sinh")]
    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày sinh không hợp lệ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Column(TypeName = "date")]
    public DateTime NnmStudentBirthday { get; set; }

    [Display(Name = "Lớp học")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn lớp học")]
    public int NnmClassId { get; set; }

    [ForeignKey(nameof(NnmClassId))]
    [ValidateNever]
    public NnmStdClass NnmClass { get; set; } = null!;

    [ValidateNever]
    public ICollection<NnmMark> NnmMarks { get; set; } = new List<NnmMark>();
}
