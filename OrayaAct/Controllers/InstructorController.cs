using Microsoft.AspNetCore.Mvc;
using OrayaAct.Models;

namespace OrayaAct.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Montano",
                IsTenured = true,
                Rank = Rank.Instructor,
                HiringDate = DateTime.Parse("2022/05/21")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Mia",
                LastName = "Eleazar",
                IsTenured = true,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("2021/05/21")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Arthur",
                LastName = "Ollanda",
                IsTenured = true,
                Rank = Rank.AssociateProfessor,
                HiringDate = DateTime.Parse("2019/05/21")
            },
            new Instructor()
            {
                Id = 4,
                FirstName = "Leonid",
                LastName = "Lintag",
                IsTenured = true,
                Rank = Rank.Professor,
                HiringDate = DateTime.Parse("2019/05/21")
            },
        };
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(x => x.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }
    }
}
