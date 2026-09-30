using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NnmLesson12EFCore.Models;

[Table("NnmMarks")]
public class NnmMark
{
    [Display(Name = "Môn học")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn môn học")]
    public int NnmSubjectId { get; set; }

    [Display(Name = "Sinh viên")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn sinh viên")]
    public int NnmStudentId { get; set; }

    [Display(Name = "Điểm")]
    [BindRequired]
    [Required(ErrorMessage = "Điểm không được để trống")]
    [Range(0, 10, ErrorMessage = "Điểm phải trong khoảng từ 0 đến 10")]
    [Column(TypeName = "float")]
    public double NnmScore { get; set; }

    [ForeignKey(nameof(NnmSubjectId))]
    [ValidateNever]
    public NnmSubject NnmSubject { get; set; } = null!;

    [ForeignKey(nameof(NnmStudentId))]
    [ValidateNever]
    public NnmStudent NnmStudent { get; set; } = null!;
}
