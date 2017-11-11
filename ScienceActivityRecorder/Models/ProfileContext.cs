using Microsoft.EntityFrameworkCore;

namespace ScienceActivityRecorder.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        { }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Profile> PersonalInfo { get; set; }

        public DbSet<PublicationActivity> PublicationActivityInfo { get; set; }

        public DbSet<ProfessionalActivity> ProfessionalActivityInfo { get; set; }

        public DbSet<AdditionalActivity> AdditionalActivityInfo { get; set; }
    }
}
