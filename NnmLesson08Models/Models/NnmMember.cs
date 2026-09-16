using System.ComponentModel;

namespace NnmLesson08Models.Models
{
    public class NnmMember
    {
        public string NnmMemberId { get; set; }
        public string NnmUserName { get;set; }
        public string NnmPassword { get; set; }

        [DisplayName("Họ và tên")]
        public string NnmFullName { get; set; }
        public string NnmEmail { get; set; }
    }

}

