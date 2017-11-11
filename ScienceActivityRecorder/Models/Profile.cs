using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceActivityRecorder.Models
{
    public class Profile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Display(Name = "Дата народження")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
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

        public List<PublicationActivity> PublicationActivity { get; set; }

        public List<ProfessionalActivity> ProfessionalActivity { get; set; }

        public List<AdditionalActivity> AdditionalActivity { get; set; }
    }
}
