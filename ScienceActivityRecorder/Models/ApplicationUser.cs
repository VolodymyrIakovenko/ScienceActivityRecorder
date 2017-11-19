using Microsoft.AspNetCore.Identity;

namespace ScienceActivityRecorder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int ProfileId { get; set; }
    }
}
