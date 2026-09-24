using Microsoft.AspNetCore.Mvc;
using NnmLesson09Annotation.Models.DataModels;
using NnmLesson09Annotation.Models.DataViewModels;

namespace NnmLesson09Annotation.Controllers
{
    public class NnmMemberController : Controller
    {
        private static readonly List<NnmMember> _members = new()
        {
            new NnmMember
            {
                NnmMemberId = 1,
                NnmUserName = "manh02847",
                NnmPassword = "Password123!",
                NnmEmail = "manh02847@example.com",
                NnmPhoneNumber = "0987654321",
                NnmFullName = "Nguyễn Ngọc Mạnh",
                NnmBirthday = new DateTime(2006, 1, 1)
            },
            new NnmMember
            {
                NnmMemberId = 2,
                NnmUserName = "tranthib",
                NnmPassword = "SecurePass456#",
                NnmEmail = "tranthib@outlook.com",
                NnmPhoneNumber = "0912345678",
                NnmFullName = "Trần Thị B",
                NnmBirthday = new DateTime(2005, 5, 10)
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult NnmCreate()
        {
            return View(new NnmMemberRegister());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NnmCreate(NnmMemberRegister nnmMember)
        {
            if (!ModelState.IsValid)
            {
                return View(nnmMember);
            }

            if (_members.Any(x => x.NnmUserName.Equals(nnmMember.NnmUserName, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError(nameof(nnmMember.NnmUserName), "Tên đăng nhập đã tồn tại");
                return View(nnmMember);
            }

            var newId = nnmMember.NnmMemberId > 0 && _members.All(x => x.NnmMemberId != nnmMember.NnmMemberId)
                ? nnmMember.NnmMemberId
                : (_members.Count == 0 ? 1 : _members.Max(x => x.NnmMemberId) + 1);

            _members.Add(new NnmMember
            {
                NnmMemberId = newId,
                NnmUserName = nnmMember.NnmUserName,
                NnmPassword = nnmMember.NnmPassword,
                NnmEmail = nnmMember.NnmEmail,
                NnmPhoneNumber = nnmMember.NnmPhoneNumber,
                NnmFullName = nnmMember.NnmFullName,
                NnmBirthday = nnmMember.NnmBirthday
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult NnmDetails(int id)
        {
            var member = _members.FirstOrDefault(x => x.NnmMemberId == id);
            return member == null ? NotFound() : View(member);
        }

        [HttpGet]
        public IActionResult NnmEdit(int id)
        {
            var member = _members.FirstOrDefault(x => x.NnmMemberId == id);
            return member == null ? NotFound() : View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NnmEdit(int id, NnmMember nnmMember)
        {
            var member = _members.FirstOrDefault(x => x.NnmMemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            member.NnmUserName = nnmMember.NnmUserName;
            member.NnmPassword = nnmMember.NnmPassword;
            member.NnmEmail = nnmMember.NnmEmail;
            member.NnmPhoneNumber = nnmMember.NnmPhoneNumber;
            member.NnmFullName = nnmMember.NnmFullName;
            member.NnmBirthday = nnmMember.NnmBirthday;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult NnmDelete(int id)
        {
            var member = _members.FirstOrDefault(x => x.NnmMemberId == id);
            return member == null ? NotFound() : View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NnmDeleted(int id)
        {
            var member = _members.FirstOrDefault(x => x.NnmMemberId == id);
            if (member != null)
            {
                _members.Remove(member);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
