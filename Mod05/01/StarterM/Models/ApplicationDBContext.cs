using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StarterM.Models
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {   
        //DI注入服務時需要使用
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base (options)
        { 
        }
    }
}
