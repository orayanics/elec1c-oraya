using OrayaAct.Models;

namespace OrayaAct.Services
{
    public interface IPopulateDataService
    {
        List<Student> StudentList { get; }
        List<Instructor> InstructorList { get; }
    }
}
