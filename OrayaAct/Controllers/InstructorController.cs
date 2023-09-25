using Microsoft.AspNetCore.Mvc;
using OrayaAct.Models;
using OrayaAct.Services;

namespace OrayaAct.Controllers
{
    public class InstructorController : Controller
    {
        // Call interface
        private IPopulateDataService? _populateData;

        // Constructor to instantiate
        public InstructorController(IPopulateDataService populateData)
        {
            _populateData = populateData;
        }

        public IActionResult Index()
        {
            return View(_populateData.InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _populateData.InstructorList.FirstOrDefault(x => x.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Instructor newInstructor)
        {
            _populateData.InstructorList.Add(newInstructor);
            return View("Index", _populateData.InstructorList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var number = (_populateData.InstructorList.Count + 1).ToString();
            ViewBag.increment = number;
            return View();
        }

        [HttpPost]
        public IActionResult Update(Instructor newInstructor)
        {
            Instructor? instructor = _populateData.InstructorList.FirstOrDefault(x => x.Id == newInstructor.Id);

            if (instructor != null)
            {
                instructor.Id = newInstructor.Id;
                instructor.FirstName = newInstructor.FirstName;
                instructor.LastName = newInstructor.LastName;
                instructor.IsTenured = newInstructor.IsTenured;
                instructor.Rank = newInstructor.Rank;
                instructor.HiringDate = newInstructor.HiringDate;
            }

            return View("Index", _populateData.InstructorList);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Instructor? instructor = _populateData.InstructorList.FirstOrDefault(x => x.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = _populateData.InstructorList.FirstOrDefault(x => x.Id == id);
            _populateData.InstructorList.Remove(instructor);
            return View("Index", _populateData.InstructorList);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Instructor? instructor = _populateData.InstructorList.FirstOrDefault(x => x.Id == id);
            if (instructor != null)
            {
                return View(instructor);
            }
            return NotFound();
        }
    }
}
