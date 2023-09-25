using Microsoft.AspNetCore.Mvc;
using OrayaAct.Models;
using OrayaAct.Services;


namespace OrayaAct.Controllers
{
    public class StudentController : Controller
    {
        // Call interface
        private IPopulateDataService? _populateData;

        // Constructor to instantiate
        public StudentController(IPopulateDataService populateData)
        {
            _populateData = populateData;
        }

        public IActionResult Index()
        {
            return View(_populateData.StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = _populateData.StudentList.FirstOrDefault(x => x.Id == id);

            if(student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Student newStudent)
        {
            _populateData.StudentList.Add(newStudent);
            return View("Index", _populateData.StudentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var idAdd = (_populateData.StudentList.Count+1).ToString();
            ViewBag.idAdd = idAdd;
            //ViewBag["increment"] = number;
            return View();
        }

        [HttpPost]
        public IActionResult Update(Student newStudent)
        {
            Student? student = _populateData.StudentList.FirstOrDefault(x => x.Id == newStudent.Id);

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

            return View("Index", _populateData.StudentList);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student? student = _populateData.StudentList.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Student? student = _populateData.StudentList.FirstOrDefault(x => x.Id == id);
            _populateData.StudentList.Remove(student);
            return View("Index", _populateData.StudentList);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Student? student = _populateData.StudentList.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                return View(student);
            }
            return NotFound();
        }
    }
}
