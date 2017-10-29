using System.ComponentModel.DataAnnotations;

namespace ScienceActivityRecorder.Models
{
    public class AdditionalActivityInfo
    {
        [Display(Name = "Участь у профорієнтаційній роботі та довузовській підготовці молоді ")]
        public string Num20VocationalGuidenceWork { get; set; }

        [Display(Name = "Керівництво спільних досліджень кафедр, експериментальних та інноваційних розробок, реального ДП які впроваджені у ВНЗ або на виробництві")]
        public string Num21ManagementOfCommonWork { get; set; }

        [Display(Name = "Керівництво або безпосередня участь у створенні лабораторій, кабінетів, проведення капітальних ремонтів")]
        public string Num22CreationOfOffices { get; set; }

        [Display(Name = "Участь у роботі Ради з якості, розроблення СТВ, НЯ, ДП, СТК, П, МІ, ІК. Участь у роботі  комісії з ВА")]
        public string Num23ParticipationInWorkOfBoards { get; set; }

        [Display(Name = "Державні нагороди та заохочення")]
        public string Num24NationalAward { get; set; }
    }
}
