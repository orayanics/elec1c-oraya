using Microsoft.AspNetCore.Identity;

namespace OrayaAct.Data
{
    public class UserIden : IdentityUser
    {
        //public string? username { get; set; }
        //public string? password { get; set; }
        // Extra Columns You Want to Add In DB
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string? email { get; set; }
    }
}
