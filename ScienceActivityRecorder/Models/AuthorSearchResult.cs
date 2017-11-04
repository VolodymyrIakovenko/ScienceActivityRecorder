using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScienceActivityRecorder.Models
{
    public class AuthorSearchResult
    {
        [Display(Name = "Автор")]
        public string NameSurname { get; set; }

        [Display(Name = "H-індекс")]
        public int HIndex { get; set; }

        [Display(Name = "Установа")]
        public string Organization { get; set; }

        [Display(Name = "Наукова галузь")]
        public string Field { get; set; }

        public string Link { get; set; }

        public IEnumerable<Publication> Publications { get; set; }
    }
}
