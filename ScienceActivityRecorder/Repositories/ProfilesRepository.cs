using System.Collections.Generic;
using ScienceActivityRecorder.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ScienceActivityRecorder.Repositories
{
    public class ProfilesRepository : IProfilesRepository
    {
        public readonly ProfileContext _dbContext;

        public ProfilesRepository(ProfileContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Profile GetProfile(int id)
        {
            return _dbContext.Profiles.
                Include(p => p.PublicationActivity).
                AsNoTracking().
                Include(p => p.ProfessionalActivity).
                AsNoTracking().
                Include(p => p.AdditionalActivity).
                AsNoTracking().
                FirstOrDefault(c => c.Id == id);
        }

        public List<Profile> GetAllProfiles()
        {
            return _dbContext.Profiles.ToList();
        }

        public void CreateProfile(Profile profile)
        {
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();
        }

        public void UpdateProfile(Profile profileToUpdate)
        {
            _dbContext.Update(profileToUpdate);
            _dbContext.SaveChanges();
        }

        public void DeleteProfile(int id)
        {
            var profileToDelete = _dbContext.Profiles.FirstOrDefault(c => c.Id == id);
            if (profileToDelete != null)
            {
                _dbContext.Remove(profileToDelete);
                _dbContext.SaveChanges();
            }
        }        
    }
}
