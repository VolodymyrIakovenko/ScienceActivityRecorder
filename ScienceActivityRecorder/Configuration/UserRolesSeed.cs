using Microsoft.AspNetCore.Identity;
using ScienceActivityRecorder.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Configuration
{
    public class UserRolesSeed
    {
        private static readonly Dictionary<string, string> userRoles = new Dictionary<string, string>
        {
            { "arbuzova.yuliya", "Employee" },
            { "zhivetc.alla", "Employee" },
            { "karlova.natalya", "Employee" },
            { "komlichenko.oksana", "Employee" },
            { "narozhnyi.oleksandr", "Employee" },
            { "nosov.pavlo", "Employee" },
            { "rotan.natalya", "Employee" },
            { "savenok.lyudmila", "Employee" },
            { "safonova.hanna", "Employee" },
            { "safonov.myhailo", "Employee" },
            { "semakova.tetiana", "Employee" },
            { "yakovenko.vira", "Employee" },
            { "yakovenko.evhen", "Employee" },
            { "yakovenko.oleksandr", "Employee" },
            { "gogunsky.viktor", "Employee" },
            { "admin", "Admin" },
        };

        public static async Task Seed(UserManager<ApplicationUser> userManager)
        {
            foreach (var userLogin in userRoles.Keys)
            {
                var user = await userManager.FindByNameAsync(userLogin);
                if (user == null)
                {
                    throw new Exception("Failed to assign a role: " + userLogin + " user wasn't found.");
                }

                var existingRoles = await userManager.GetRolesAsync(user);
                if (existingRoles.Contains(userRoles[userLogin]))
                {
                    continue;
                }

                var result = await userManager.AddToRoleAsync(user, userRoles[userLogin]);
                if (!result.Succeeded)
                {
                    var exceptionText = "Failed to assign a role: ";
                    foreach (var item in result.Errors)
                    {
                        exceptionText += item.Description + "; ";
                    }

                    throw new Exception(exceptionText);
                }
            }
        }
    }
}
