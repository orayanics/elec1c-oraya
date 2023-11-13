using System.ComponentModel.DataAnnotations;

namespace OrayaAct.Models
{
    public enum Course
    {
        BSIT, BSCS, BSIS, OTHER
    }

    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Student GPA")]
        public double GPA { get; set; }
        [Display(Name = "Enrolled Course")]
        public Course Course { get; set; }
        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }

}
