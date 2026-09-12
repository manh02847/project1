using Microsoft.AspNetCore.Mvc;
using NnmLesson07Models.Models.DataModels;

namespace NnmLesson07Models.Controllers
{
    public class NnmMemberController : Controller
    {
        // Mock Data
        protected static List<NnmMember> _members = new List<NnmMember>
        {
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "manh02847",
                NnmPassword = "123456",
                NnmFullName = "Nguyễn Ngọc Mạnh",
                NnmEmail = "manh02847@example.com"
            },
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "tranthibinh",
                NnmPassword = "123456",
                NnmFullName = "Trần Thị Bình",
                NnmEmail = "tranthibinh@example.com"
            },
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "levancuong",
                NnmPassword = "123456",
                NnmFullName = "Lê Văn Cường",
                NnmEmail = "levancuong@example.com"
            },
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "phamthiduyen",
                NnmPassword = "123456",
                NnmFullName = "Phạm Thị Duyên",
                NnmEmail = "phamthiduyen@example.com"
            },
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "hoangminhduc",
                NnmPassword = "123456",
                NnmFullName = "Hoàng Minh Đức",
                NnmEmail = "hoangminhduc@example.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }

        public IActionResult GetMember()
        {
            var member = new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "manh02847",
                NnmPassword = "password123",
                NnmFullName = "Nguyễn Ngọc Mạnh",
                NnmEmail = "manh02847@example.com"
            };
            //ViewBag.Member = member;
            return View(member);
        }

        // Đưa dữ liệu dạng List ra View
        public IActionResult GetMembers()
        {
            // Lấy từ mock data
            ViewBag.Members = _members;
            return View();
        }

        // GET: Create member
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NnmMember member)
        {
            if (ModelState.IsValid)
            {
                member.NnmMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
