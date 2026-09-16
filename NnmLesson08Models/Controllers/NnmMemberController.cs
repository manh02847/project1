using Microsoft.AspNetCore.Mvc;
using NnmLesson08Models.Models;

namespace NnmLesson08Models.Controllers
{
    public class NnmMemberController : Controller
    {
        // Mock data - NnmMember
        private static List<NnmMember> _members = new List<NnmMember>()
        {
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "manh02847",
                NnmPassword = "Password123!",
                NnmFullName = "Nguyễn Ngọc Mạnh",
                NnmEmail = "manh02847@example.com"
            },
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "tranthib",
                NnmPassword = "SecurePass456#",
                NnmFullName = "Trần Thị B",
                NnmEmail = "tranthib@outlook.com"
            },
            new NnmMember
            {
                NnmMemberId = Guid.NewGuid().ToString(),
                NnmUserName = "levanc",
                NnmPassword = "MyPassword789$",
                NnmFullName = "Lê Văn C",
                NnmEmail = "levanc@company.com"
            }
        };

        // GET: Danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult NnmCreate()
        {
            var member = new NnmMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult NnmCreate(NnmMember nnmMember)
        {
            nnmMember.NnmMemberId = Guid.NewGuid().ToString();
            _members.Add(nnmMember);

            return RedirectToAction("Index");
            //return View(nnmMember);
        }

        [HttpGet]
        public IActionResult NnmEdit(string id)
        {
            var member = _members.Where(x=>x.NnmMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult NnmEdit(string id, NnmMember nnmMember)
        {
            // var member = _members.Where(x => x.NnmMemberId.Equals(id)).FirstOrDefault();
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].NnmMemberId == id)
                {
                    _members[i].NnmUserName = nnmMember.NnmUserName;
                    _members[i].NnmPassword = nnmMember.NnmPassword;
                    _members[i].NnmFullName= nnmMember.NnmFullName;
                    _members[i].NnmEmail=   nnmMember.NnmEmail;

                    return RedirectToAction("Index");
                }
           
            }
            return View();
        }

        [HttpGet]
        public IActionResult NnmDetails(string id)
        {
            var member = _members.Where(x => x.NnmMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpGet]
        public IActionResult NnmDelete(string id)
        {
            var member = _members.Where(x => x.NnmMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult NnmDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.NnmMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("NnmDelete");
        }
    }
}
