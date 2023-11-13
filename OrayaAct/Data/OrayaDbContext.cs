using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrayaAct.Models;
using OrayaAct.Data;

namespace OrayaAct.Database
{
    public class OrayaDbContext : IdentityDbContext<UserIden>
    {
        // Declare and set your tables
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        // Constructor
        public OrayaDbContext(DbContextOptions<OrayaDbContext> options) : base(options) { }

        // Add service to Program.cs and context for database creation

        // Optional: Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Nicole",
                    LastName = "Oraya",
                    GPA = 1.4,
                    Course = Course.BSIT,
                    AdmissionDate = DateTime.Parse("2022/1/31"),
                    Email = "nicole.oraya.cics@ust.edu.ph"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Miguel",
                    LastName = "Oraya",
                    GPA = 1.5,
                    Course = Course.BSIS,
                    AdmissionDate = DateTime.Parse("2019/05/23"),
                    Email = "miguel.oraya.cics@ust.edu.ph"
                }
                );

            modelBuilder.Entity<Instructor>().HasData(
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
                }
                );
        }
    }
}

