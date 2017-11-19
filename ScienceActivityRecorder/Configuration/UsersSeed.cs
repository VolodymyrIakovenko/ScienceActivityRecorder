using Microsoft.AspNetCore.Identity;
using ScienceActivityRecorder.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Configuration
{
    public class UsersSeed
    {
        private static readonly Dictionary<ApplicationUser, string> users = new Dictionary<ApplicationUser, string>
        {
            {
                new ApplicationUser { UserName = "oleksandr.iakovenko", ProfileId = 1 },
                "Abc1234%"
            },

            {
                new ApplicationUser { UserName = "admin", ProfileId = 0 },
                "Abc1234%"
            }
        };

        public static async Task Seed(UserManager<ApplicationUser> userManager)
        {
            foreach (var appUser in users.Keys)
            {
                if (await userManager.FindByNameAsync(appUser.UserName) == null)
                {
                    var result = await userManager.CreateAsync(appUser, users[appUser]);
                    if (!result.Succeeded)
                    {
                        var exceptionText = "Failed to create a user: ";
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
}
