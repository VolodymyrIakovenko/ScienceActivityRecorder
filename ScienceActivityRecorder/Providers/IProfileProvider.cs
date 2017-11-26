using ScienceActivityRecorder.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Providers
{
    public interface IProfileProvider
    {
        Task<Profile> GetCurrentProfile(ClaimsPrincipal claimsPrincipal);
    }
}