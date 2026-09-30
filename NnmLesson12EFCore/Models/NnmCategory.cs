using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NnmLesson12EFCore.Models;

[Table("NnmCategory")]
public class NnmCategory
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Tên danh mục")]
    [Required(ErrorMessage = "Tên danh mục không được để trống")]
    [StringLength(100, ErrorMessage = "Tên danh mục tối đa 100 ký tự")]
    [Column(TypeName = "nvarchar(100)")]
    public string NnmName { get; set; } = string.Empty;

    [Display(Name = "Trạng thái")]
    [Range(0, 1, ErrorMessage = "Trạng thái phải là 0 hoặc 1")]
    [Column(TypeName = "tinyint")]
    public byte NnmStatus { get; set; } = 1;

    [Display(Name = "Ngày tạo")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime NnmCreatedDate { get; set; }

    [ValidateNever]
    public ICollection<NnmProduct> NnmProducts { get; set; } = new List<NnmProduct>();
}
