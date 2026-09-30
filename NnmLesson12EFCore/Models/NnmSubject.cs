using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NnmLesson12EFCore.Models;

[Table("NnmSubjects")]
public class NnmSubject
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Tên môn học")]
    [Required(ErrorMessage = "Tên môn học không được để trống")]
    [StringLength(100, ErrorMessage = "Tên môn học tối đa 100 ký tự")]
    [Column(TypeName = "nvarchar(100)")]
    public string NnmSubjectName { get; set; } = string.Empty;

    [ValidateNever]
    public ICollection<NnmMark> NnmMarks { get; set; } = new List<NnmMark>();
}
