using Microsoft.EntityFrameworkCore;

namespace ScienceActivityRecorder.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        { }
        
        public DbSet<PersonalInfo> PersonalInfo { get; set; }

        public DbSet<PublicationActivityInfo> PublicationActivityInfo { get; set; }

        public DbSet<ProfessionalActivityInfo> ProfessionalActivityInfo { get; set; }

        public DbSet<AdditionalActivityInfo> AdditionalActivityInfo { get; set; }
    }
}
