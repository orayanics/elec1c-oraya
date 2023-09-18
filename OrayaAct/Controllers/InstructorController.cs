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
                HiringDate = DateOnly.Parse("2022/05/21")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Mia",
                LastName = "Eleazar",
                IsTenured = true,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateOnly.Parse("2021/05/21")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Arthur",
                LastName = "Ollanda",
                IsTenured = true,
                Rank = Rank.AssociateProfessor,
                HiringDate = DateOnly.Parse("2019/05/21")
            },
            new Instructor()
            {
                Id = 4,
                FirstName = "Leonid",
                LastName = "Lintag",
                IsTenured = true,
                Rank = Rank.Professor,
                HiringDate = DateOnly.Parse("2019/05/21")
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

        [HttpPost]
        public IActionResult Add(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Instructor newInstructor)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(x => x.Id == newInstructor.Id);

            if (instructor != null)
            {
                instructor.Id = newInstructor.Id;
                instructor.FirstName = newInstructor.FirstName;
                instructor.LastName = newInstructor.LastName;
                instructor.IsTenured = newInstructor.IsTenured;
                instructor.Rank = newInstructor.Rank;
                instructor.HiringDate = newInstructor.HiringDate;
            }

            return View("Index", InstructorList);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(x => x.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(x => x.Id == id);
            InstructorList.Remove(instructor);
            return View("Index", InstructorList);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
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
