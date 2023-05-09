using Microsoft.AspNetCore.Identity;

namespace InnovaCatalogIdentity.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
