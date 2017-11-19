using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Configuration
{
    public static class RolesSeed
    {
        private static readonly string[] roles = new[] {
            "Employee",
            "Expert",
            "Admin"
        };

        public static async Task Seed(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!result.Succeeded)
                    {
                        var exceptionText = "Failed to create a role: ";
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
