using Microsoft.AspNetCore.Mvc;
using OrayaAct.Models;

namespace OrayaAct.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
        {
            new Student()
            {
                Id = 1,
                FirstName = "Nicole",
                LastName = "Oraya",
                GPA = 1.4,
                Course = Course.BSIT,
                AdmissionDate = DateTime.Parse("2022/06/27"),
                Email = "nicole.oraya.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 2,
                FirstName = "Miguel",
                LastName = "Oraya",
                GPA = 1.5,
                Course = Course.BSIS,
                AdmissionDate = DateTime.Parse("2019/05/27"),
                Email = "miguel.oraya.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 3,
                FirstName = "Josephine",
                LastName = "Oraya",
                GPA = 1.3,
                Course = Course.BSCS,
                AdmissionDate = DateTime.Parse("2018/02/1"),
                Email = "josephine.oraya.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 4,
                FirstName = "Bada",
                LastName = "Lee",
                GPA = 1.4,
                Course = Course.OTHER,
                AdmissionDate = DateTime.Parse("2022/06/28"),
                Email = "bada.lee.cics@ust.edu.ph"
            }

        };


        public IActionResult Index()
        {
            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = StudentList.FirstOrDefault(x => x.Id == id);

            if(student != null)
            {
                return View(student);
            }

            return NotFound();
        }
    }
}
