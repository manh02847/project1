namespace NnmLesson09Annotation.Models.DataModels
{
    public class NnmMember
    {
        public int NnmMemberId { get; set; }
        public string NnmUserName { get; set; } = string.Empty;
        public string NnmPassword { get; set; } = string.Empty;
        public string? NnmEmail { get; set; }
        public string? NnmPhoneNumber { get; set; }
        public string? NnmFullName { get; set; }
        public DateTime? NnmBirthday { get; set; }
    }
}
