using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceActivityRecorder.Models
{
    public class PublicationActivity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime LastFillDate { get; set; }

        [Display(Name = "Наявність наукової публікації у періодичному виданні, яке включено до наукометричних баз, зокрема Scopus або Web of Science Core Collection, рекомендованих МОН")]
        public string Num1PublicationsInScienceMetricDatabases { get; set; }

        [Display(Name = "Наявність наукових публікацій у наукових виданнях, включених до переліку наукових фахових видань України, та/або авторських свідоцтв, та/або патентів загальною кількістю п’ять досягнень")]
        public string Num2PublicationsInUkrainianDatabases { get; set; }

        [Display(Name = "Наявність виданого підручника чи навчального посібника, що рекомендований МОН, іншим центральним органом виконавчої влади або вченою радою закладу освіти, або монографії (у разі співавторства - з фіксованим власним внеском)")]
        public string Num3TextbookAvailability { get; set; }

        [Display(Name = "Наявність виданих навчально-методичних посібників /посібників для самостійної роботи студентів та дистанційного навчання/ конспектів лекцій/ практикумів/ методичних вказівок/ рекомендацій загальною кількістю три найменування")]
        public string Num14TeachingManualsAvailibility { get; set; }

        [Display(Name = "Наявність науково-популярних та/або консультаційних (дорадчих) та/або дискусійних публікацій з наукової або професійної тематики загальною кількістю три публікації")]
        public string Num18PopularSciencePublicationsAvailibility { get; set; }        
    }
}
