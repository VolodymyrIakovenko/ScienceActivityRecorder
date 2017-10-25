using System;
using System.ComponentModel.DataAnnotations;

namespace ScienceActivityRecorder.Models
{
    public class PersonalInfo
    {
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [DisplayFormat(DataFormatString = "dd.MM.yyyy")]
        [Display(Name = "Дата народження")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Посада, рік")]
        public string Position { get; set; }

        [Display(Name = "Педагогічне звання, посада")]
        public string Degree { get; set; }

        [Display(Name = "Найменування закладу, який закінчив викладач")]
        public string EducationalInstitution { get; set; }

        [Display(Name = "Найменування всіх навчальних дисциплін, які закріплені за викладачем")]
        public string AcademicDisciplines { get; set; }

        [Display(Name = "Відомості про підвищення кваліфікації викладача")]
        public string AdvancedTraining { get; set; }

        [Display(Name = "Вислуга років")]
        public string Seniority { get; set; }

        [Display(Name = "Домашня адреса, телефон")]
        public string HomeAddress { get; set; }
    }
}
