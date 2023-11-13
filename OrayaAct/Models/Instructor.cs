using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrayaAct.Models
{
    public enum Rank
    {
        Instructor,
        AssistantProfessor,
        AssociateProfessor,
        Professor
    }

    public class Instructor
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "First Name")]
        public string LastName { get; set; }
        [Display(Name = "Position")]
        public Rank Rank { get; set; }
        [Display(Name = "Status")]
        public Boolean IsTenured { get; set; }
        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

    }
}
