using System.ComponentModel.DataAnnotations;

namespace ScienceActivityRecorder.Models
{
    public class Publication
    {
        [Display(Name = "Назва статті")]
        public string Name { get; set; }

        [Display(Name = "Автори")]
        public string Authors { get; set; }

        [Display(Name = "Науковий журнал")]
        public string Journal { get; set; }

        [Display(Name = "Рік публікації")]
        public int Year { get; set; }
    }
}
