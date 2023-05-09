using Microsoft.AspNetCore.Identity;

namespace InnovaCatalog_Identity.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
