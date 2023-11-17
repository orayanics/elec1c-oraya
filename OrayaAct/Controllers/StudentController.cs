using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrayaAct.Database;
using OrayaAct.Models;
using OrayaAct.Services;


namespace OrayaAct.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        // Call interface
        // private IPopulateDataService? _populateData;

        // Db Context
        private readonly OrayaDbContext _dbContext;

        // Constructor to instantiate
        //public StudentController(IPopulateDataService populateData)
        //{
        //    _populateData = populateData;
        //}

        public StudentController(OrayaDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IActionResult Index()
        {
            return View(_dbContext.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(x => x.Id == id);

            if(student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Student newStudent)
        {
            _dbContext.Students.Add(newStudent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var number = _dbContext.Instructors.Count() + 1;
            ViewBag.increment = number;
            return View();
        }

        [HttpPost]
        public IActionResult Update(Student newStudent)
        {
            Student? student = _dbContext.Students.FirstOrDefault(x => x.Id == newStudent.Id);

            if (student != null)
            {
                student.Id = newStudent.Id;
                student.FirstName = newStudent.FirstName;
                student.LastName = newStudent.LastName;
                student.GPA = newStudent.GPA;
                student.Course = newStudent.Course;
                student.AdmissionDate = newStudent.AdmissionDate;
                student.Email = newStudent.Email;
                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                return View(student);
            }
            return NotFound();
        }
    }
}
