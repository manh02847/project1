namespace NnmLesson10EFDbFirst.Models;

public partial class NnmMember
{
    public long Id { get; set; }

    public string? NnmUserName { get; set; }

    public string? NnmPassword { get; set; }

    public string? NnmFullName { get; set; }

    public string? NnmEmail { get; set; }

    public string? NnmPhone { get; set; }

    public bool? NnmStatus { get; set; }
}
