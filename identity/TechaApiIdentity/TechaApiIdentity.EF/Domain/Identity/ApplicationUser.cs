using Microsoft.AspNetCore.Identity;

namespace TechaApiIdentity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public long? NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
