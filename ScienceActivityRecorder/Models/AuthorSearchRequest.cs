using System.ComponentModel.DataAnnotations;

namespace ScienceActivityRecorder.Models
{
    public class AuthorSearchRequest
    {
        [MinLength(3, ErrorMessage = "Ім'я та прізвище занадто короткі")]
        [Required(ErrorMessage = "Введіть будь-ласка ім'я та прізвище")]
        [Display(Name = "Ім'я та прізвище")]
        public string NameSurname { get; set; }

        [Display(Name = "Установа")]
        public string Organization { get; set; }

        [Display(Name = "Ключові слова")]
        public string Keywords { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Будь-ласка введіть число більше за 0")]
        [Display(Name = "Максимальна кількість результатів")]
        public int NumberOfRecords { get; set; }
    }
}
