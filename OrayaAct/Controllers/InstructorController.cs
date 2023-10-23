using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using OrayaAct.Database;
using OrayaAct.Models;
using OrayaAct.Services;

namespace OrayaAct.Controllers
{
    public class InstructorController : Controller
    {
        // Call interface
        // private IPopulateDataService? _populateData;

        // Db Context
        private readonly OrayaDbContext _dbContext;

        // Constructor to instantiate
        //public InstructorController(IPopulateDataService populateData)
        //{
        //    _populateData = populateData;
        //}

        public InstructorController(OrayaDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        //public IActionResult Index()
        //{
        //    return View(_populateData.InstructorList);
        //}

        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(x => x.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        //[Bind("Id,FirstName,LastName,Rank,IsTenured,HiringDate")]

        [HttpPost]
        public IActionResult Add(Instructor newInstructor)
        {
            
            if (ModelState.IsValid)
            {               
                _dbContext.Instructors.Add(newInstructor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newInstructor);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            var number = _dbContext.Instructors.Count() + 1;
            ViewBag.increment = number.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult Update(Instructor newInstructor)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(x => x.Id == newInstructor.Id);

            if (instructor != null)
            {
                instructor.Id = newInstructor.Id;
                instructor.FirstName = newInstructor.FirstName;
                instructor.LastName = newInstructor.LastName;
                instructor.IsTenured = newInstructor.IsTenured;
                instructor.Rank = newInstructor.Rank;
                instructor.HiringDate = newInstructor.HiringDate;
                _dbContext.Instructors.Update(instructor);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(x => x.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(x => x.Id == id);
            _dbContext.Instructors.Remove(instructor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(x => x.Id == id);
            if (instructor != null)
            {
                return View(instructor);
            }
            return NotFound();
        }
    }
}
