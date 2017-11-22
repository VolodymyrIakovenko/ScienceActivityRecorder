using System.ComponentModel.DataAnnotations;

namespace ScienceActivityRecorder.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Логін")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати")]
        public bool RememberMe { get; set; }
    }
}
