using ScienceActivityRecorder.Models;
using System;

namespace ScienceActivityRecorder.Providers
{
    public static class PersonalInfoProvider
    {
        public static PersonalInfo IakovenkoOE
        {
            get
            {
                var personalInfo = new PersonalInfo
                {
                    LastName = "Яковенко",
                    FirstName = "Олександр",
                    MiddleName = "Євгенович",
                    BirthDate = new DateTime(1960, 1, 1),
                    Position = "Доцент, Херсонський політехнічний коледж Одеського національного політехнічного університету, директор, з 2001",
                    Degree = "Кандидат технічних наук, викладач, доцент за кафедрою «Природничо-наукової підготовки» спеціаліст вищої категорії, викладач методист",
                    EducationalInstitution = "Київський політехнічний інститут, 1988р. «Електронні обчислювальні машини», інженер-системотехнік.",
                    AcademicDisciplines = "Архітектура комп’ютерів (70), Комп’ютерна схемотехніка (30)",
                    AdvancedTraining = "Університет менеджменту освіти НАПН України ДВНЗ «Університет менеджменту освіти центральний інститут післядипломної педагогічної освіти, директори ВНЗ І-ІІ р.а.», 27.01.2014 – 27.06.2014, свід. № 875/14 Ц від 27.06.2014, «Відкрита освіта і дистанційне навчання у ВНЗ»",
                    Seniority = "30",
                    HomeAddress = "м.Херсон, вул. Небесної сотні (40 років Жовтня), буд. 23-а, к. 35-41, (0552) 39-78-41"
                };

                return personalInfo;
            }
        }
    }
}
