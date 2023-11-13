using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrayaAct.ViewModel
{
    [Table("AspNetUsers")]
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
