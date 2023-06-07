using Microsoft.AspNetCore.Identity;

namespace StarterM.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? City { get; set; }
    }
}
