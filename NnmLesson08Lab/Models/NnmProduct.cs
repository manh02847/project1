using System.ComponentModel.DataAnnotations;

namespace NnmLesson08Lab.Models
{
    public class NnmProduct
    {
        [Display(Name = "Mã sản phẩm")]
        public int NnmProductId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string NnmProductName { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá")]
        public decimal NnmPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mại phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá khuyến mại")]
        public decimal NnmSalePrice { get; set; }

        [Display(Name = "Trạng thái")]
        public bool NnmStatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        public DateTime NnmCreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Hình ảnh")]
        public string? NnmImage { get; set; }

        [Display(Name = "Danh mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục")]
        public int NnmCategoryId { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Mô tả")]
        public string? NnmDescription { get; set; }
    }
}
