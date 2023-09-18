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
                AdmissionDate = DateOnly.Parse("2022/1/31"),
                Email = "nicole.oraya.cics@ust.edu.ph"
            },
            //new Student()
            //{
            //    Id = 2,
            //    FirstName = "Miguel",
            //    LastName = "Oraya",
            //    GPA = 1.5,
            //    Course = Course.BSIS,
            //    AdmissionDate = DateOnly.Parse("2019/05/23"),
            //    Email = "miguel.oraya.cics@ust.edu.ph"
            //},
            //new Student()
            //{
            //    Id = 3,
            //    FirstName = "Josephine",
            //    LastName = "Oraya",
            //    GPA = 1.3,
            //    Course = Course.BSCS,
            //    AdmissionDate = DateOnly.Parse("2018/02/01"),
            //    Email = "josephine.oraya.cics@ust.edu.ph"
            //},
            //new Student()
            //{
            //    Id = 4,
            //    FirstName = "Bada",
            //    LastName = "Lee",
            //    GPA = 1.4,
            //    Course = Course.OTHER,
            //    AdmissionDate = DateOnly.Parse("2022/06/28"),
            //    Email = "bada.lee.cics@ust.edu.ph"
            //}

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

        [HttpPost]
        public IActionResult Add(Student newStudent)
        {
            StudentList.Add(newStudent);
            return View("Index", StudentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Student newStudent)
        {
            Student? student = StudentList.FirstOrDefault(x => x.Id == newStudent.Id);

            if (student != null)
            {
                student.Id = newStudent.Id;
                student.FirstName = newStudent.FirstName;
                student.LastName = newStudent.LastName;
                student.GPA = newStudent.GPA;
                student.Course = newStudent.Course;
                student.AdmissionDate = newStudent.AdmissionDate;
                student.Email = newStudent.Email;
            }

            return View("Index", StudentList);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student? student = StudentList.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }
    }
}
