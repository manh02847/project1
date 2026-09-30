using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NnmLesson12EFCore.Models;

[Table("NnmBanner")]
public class NnmBanner
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Tên banner")]
    [Required(ErrorMessage = "Tên banner không được để trống")]
    [StringLength(150, ErrorMessage = "Tên banner tối đa 150 ký tự")]
    [Column(TypeName = "nvarchar(150)")]
    public string NnmName { get; set; } = string.Empty;

    [Display(Name = "Ảnh banner")]
    [Column(TypeName = "varchar(150)")]
    public string? NnmImage { get; set; }

    [Display(Name = "Mô tả")]
    [StringLength(1000, ErrorMessage = "Mô tả tối đa 1000 ký tự")]
    [Column(TypeName = "nvarchar(1000)")]
    public string? NnmDescription { get; set; }

    [Display(Name = "Ngày tạo")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime NnmCreatedDate { get; set; }

    [Display(Name = "Trạng thái")]
    [Range(0, 1, ErrorMessage = "Trạng thái phải là 0 hoặc 1")]
    [Column(TypeName = "tinyint")]
    public byte NnmStatus { get; set; } = 1;
}
