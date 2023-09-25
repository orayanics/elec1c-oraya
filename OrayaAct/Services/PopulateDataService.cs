using OrayaAct.Models;
using System.Security.Cryptography.X509Certificates;

namespace OrayaAct.Services
{
    public class PopulateDataService : IPopulateDataService
    {
        public List<Student> StudentList {  get; }
        public List<Instructor> InstructorList { get; }

        // Constructor
        public PopulateDataService()
        {
           StudentList = new List<Student>()
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
                new Student()
                {
                    Id = 2,
                    FirstName = "Miguel",
                    LastName = "Oraya",
                    GPA = 1.5,
                    Course = Course.BSIS,
                    AdmissionDate = DateOnly.Parse("2019/05/23"),
                    Email = "miguel.oraya.cics@ust.edu.ph"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Josephine",
                    LastName = "Oraya",
                    GPA = 1.3,
                    Course = Course.BSCS,
                    AdmissionDate = DateOnly.Parse("2018/02/01"),
                    Email = "josephine.oraya.cics@ust.edu.ph"
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Bada",
                    LastName = "Lee",
                    GPA = 1.4,
                    Course = Course.OTHER,
                    AdmissionDate = DateOnly.Parse("2022/06/28"),
                    Email = "bada.lee.cics@ust.edu.ph"
                }
           };

            InstructorList = new List<Instructor>()
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
        }
    }

    
}
