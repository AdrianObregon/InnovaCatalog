using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace InnovaCatalog_Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplciationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        

           

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}
