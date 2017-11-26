using Microsoft.AspNetCore.Identity;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Repositories;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Providers
{
    public class ProfileProvider : IProfileProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfilesRepository _profilesRepository;

        public ProfileProvider(UserManager<ApplicationUser> userManager, IProfilesRepository profilesRepository)
        {
            _userManager = userManager;
            _profilesRepository = profilesRepository;
        }

        public static DateTime NextLastFillDate
        {
            get
            {
                return new DateTime(2017, 12, 31);
            }
        }

        public async Task<Profile> GetCurrentProfile(ClaimsPrincipal claimsPrincipal)
        {
            var profileId = 0;
            
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            if (user != null)
            {
                profileId = user.ProfileId;
            }

            var profile = _profilesRepository.GetProfile(profileId);
            return profile;
        }
    }
}
