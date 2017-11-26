using Microsoft.AspNetCore.Identity;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Configuration
{
    public class UsersSeed
    {
        private Dictionary<ApplicationUser, string> _users;

        public UsersSeed(IProfilesRepository profilesRepository)
        {
            var existingProfiles = profilesRepository.GetAllProfiles();

            var arbuzovaProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Арбузова" && p.FirstName == "Юлія" && p.MiddleName == "Вікторівна");
            var arbuzovaId = arbuzovaProfile == null ? 0 : arbuzovaProfile.Id;

            var zhivetcProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Живець" && p.FirstName == "Алла" && p.MiddleName == "Миколаївна");
            var zhivetcId = zhivetcProfile == null ? 0 : zhivetcProfile.Id;

            var karlovaProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Карлова" && p.FirstName == "Наталя" && p.MiddleName == "Іванівна");
            var karlovaId = karlovaProfile == null ? 0 : karlovaProfile.Id;

            var komlichenkoProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Комліченко" && p.FirstName == "Оксана" && p.MiddleName == "Олександрівна");
            var komlichenkoId = komlichenkoProfile == null ? 0 : komlichenkoProfile.Id;

            var narozhnyiProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Нарожний" && p.FirstName == "Олександр" && p.MiddleName == "Васильович");
            var narozhnyiId = narozhnyiProfile == null ? 0 : narozhnyiProfile.Id;

            var nosovProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Носов" && p.FirstName == "Павло" && p.MiddleName == "Сергійович");
            var nosovId = nosovProfile == null ? 0 : nosovProfile.Id;

            var rotanProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Ротань" && p.FirstName == "Наталя" && p.MiddleName == "Вікторівна");
            var rotanId = rotanProfile == null ? 0 : rotanProfile.Id;

            var savenokProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Савенок" && p.FirstName == "Людмила" && p.MiddleName == "Андріївна");
            var savenokId = savenokProfile == null ? 0 : savenokProfile.Id;

            var safonovaProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Сафонова" && p.FirstName == "Ганна" && p.MiddleName == "Феліксівна");
            var safonovaId = safonovaProfile == null ? 0 : safonovaProfile.Id;

            var safonovProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Сафонов" && p.FirstName == "Михайло" && p.MiddleName == "Сергійович");
            var safonovId = safonovProfile == null ? 0 : safonovProfile.Id;

            var semakovaProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Семакова" && p.FirstName == "Тетяна" && p.MiddleName == "Олексіївна");
            var semakovaId = semakovaProfile == null ? 0 : semakovaProfile.Id;

            var yakovenkoVDProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Яковенко" && p.FirstName == "Віра" && p.MiddleName == "Дмитрівна");
            var yakovenkoVDId = yakovenkoVDProfile == null ? 0 : yakovenkoVDProfile.Id;

            var yakovenkoEOProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Яковенко" && p.FirstName == "Євген" && p.MiddleName == "Олександрович");
            var yakovenkoEOId = yakovenkoEOProfile == null ? 0 : yakovenkoEOProfile.Id;

            var yakovenkoOEProfile = existingProfiles.FirstOrDefault(p => p.LastName == "Яковенко" && p.FirstName == "Олександр" && p.MiddleName == "Євгенович");
            var yakovenkoOEId = yakovenkoOEProfile == null ? 0 : yakovenkoOEProfile.Id;

            _users = new Dictionary<ApplicationUser, string>
            {
                {
                    new ApplicationUser { UserName = "arbuzova.yuliya", ProfileId = arbuzovaId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "zhivetc.alla", ProfileId = zhivetcId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "karlova.natalya", ProfileId = karlovaId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "komlichenko.oksana", ProfileId = komlichenkoId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "narozhnyi.oleksandr", ProfileId = narozhnyiId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "nosov.pavlo", ProfileId = nosovId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "rotan.natalya", ProfileId = rotanId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "savenok.lyudmila", ProfileId = savenokId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "safonova.hanna", ProfileId = safonovaId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "safonov.myhailo", ProfileId = safonovId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "semakova.tetiana", ProfileId = semakovaId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "yakovenko.vira", ProfileId = yakovenkoVDId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "yakovenko.evhen", ProfileId = yakovenkoEOId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "yakovenko.oleksandr", ProfileId = yakovenkoOEId },
                    "Abc1234%"
                },

                {
                    new ApplicationUser { UserName = "admin", ProfileId = 0 },
                    "Abc1234%"
                }
            };
        }

        public async Task Seed(UserManager<ApplicationUser> userManager)
        {
            foreach (var appUser in _users.Keys)
            {
                if (await userManager.FindByNameAsync(appUser.UserName) == null)
                {
                    var result = await userManager.CreateAsync(appUser, _users[appUser]);
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
