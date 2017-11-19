using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScienceActivityRecorder.Models
{
    public class ProfileContext : IdentityDbContext<ApplicationUser>
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        { }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Profile> PersonalInfo { get; set; }

        public DbSet<PublicationActivity> PublicationActivity { get; set; }

        public DbSet<ProfessionalActivity> ProfessionalActivity { get; set; }

        public DbSet<AdditionalActivity> AdditionalActivity { get; set; }
    }
}
