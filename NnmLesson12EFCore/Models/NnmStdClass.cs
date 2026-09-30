using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NnmLesson12EFCore.Models;

[Table("NnmStdClass")]
public class NnmStdClass
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Tên lớp")]
    [Required(ErrorMessage = "Tên lớp không được để trống")]
    [StringLength(100, ErrorMessage = "Tên lớp tối đa 100 ký tự")]
    [Column(TypeName = "nvarchar(100)")]
    public string NnmClassName { get; set; } = string.Empty;

    [ValidateNever]
    public ICollection<NnmStudent> NnmStudents { get; set; } = new List<NnmStudent>();
}
