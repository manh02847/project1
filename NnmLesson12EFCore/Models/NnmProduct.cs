using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NnmLesson12EFCore.Models;

[Table("NnmProduct")]
public class NnmProduct
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Tên sản phẩm")]
    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")]
    [Column(TypeName = "nvarchar(150)")]
    public string NnmName { get; set; } = string.Empty;

    [Display(Name = "Ảnh sản phẩm")]
    [Column(TypeName = "varchar(150)")]
    public string? NnmImage { get; set; }

    [Display(Name = "Giá bán")]
    [Required(ErrorMessage = "Giá bán không được để trống")]
    [Range(0.01, 1000000000, ErrorMessage = "Giá bán phải lớn hơn 0 và không quá 1 tỷ")]
    [Column(TypeName = "real")]
    public float NnmPrice { get; set; }

    [Display(Name = "Giá khuyến mại")]
    [Range(0, 1000000000, ErrorMessage = "Giá khuyến mại từ 0 đến 1 tỷ")]
    [Column(TypeName = "real")]
    public float NnmSalePrice { get; set; }

    [Display(Name = "Trạng thái")]
    [Range(0, 1, ErrorMessage = "Trạng thái phải là 0 hoặc 1")]
    [Column(TypeName = "tinyint")]
    public byte NnmStatus { get; set; } = 1;

    [Display(Name = "Mô tả")]
    [StringLength(1000, ErrorMessage = "Mô tả tối đa 1000 ký tự")]
    [Column(TypeName = "ntext")]
    public string? NnmDescriptions { get; set; }

    [Display(Name = "Danh mục")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục")]
    public int NnmCategoryId { get; set; }

    [Display(Name = "Ngày tạo")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime NnmCreatedDate { get; set; }

    [ForeignKey(nameof(NnmCategoryId))]
    [ValidateNever]
    public NnmCategory NnmCategory { get; set; } = null!;
}
