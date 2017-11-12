using ScienceActivityRecorder.Models;
using System.Collections.Generic;

namespace ScienceActivityRecorder.Repositories
{
    public interface IProfilesRepository
    {
        Profile GetProfile(int id);

        List<Profile> GetAllProfiles();

        void CreateProfile(Profile profile);

        void UpdateProfile(Profile profileToUpdate);

        void DeleteProfile(int id);
    }
}
