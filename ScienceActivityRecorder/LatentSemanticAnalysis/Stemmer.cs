using System.Collections.Generic;
using System.Linq;

namespace ScienceActivityRecorder.LatentSemanticAnalysis
{
    class Stemmer
    {
        List<string> word_ends = new List<string>()
        {
            "а", "ам", "ами", "ах", "та",
            "в", "вав", "вавсь", "вався", "вала", "валась", "валася", "вали", "вались", "валися", "вало", "валось", "валося", "вати", "ватись", "ватися", "всь", "вся",
            "е", "еві", "ем", "ею",
            "є", "ємо", "ємось", "ємося", "ється", "єте", "єтесь", "єтеся", "єш", "єшся", "єю",
            "и", "ив", "ий", "ила", "или", "ило", "илося", "им", "ими", "имо", "имось", "имося", "ите", "итесь", "итеся", "ити", "ить", "иться", "их", "иш", "ишся",
            "й", "ймо", "ймось", "ймося", "йсь", "йся", "йте", "йтесь", "йтеся",
            "і", "ів", "ій", "ім", "імо", "ість", "істю", "іть",
            "ї",
            "ла", "лась", "лася", "ло", "лось", "лося", "ли", "лись", "лися",
            "о", "ові", "овував", "овувала", "овувати", "ого", "ої", "ок", "ом", "ому", "осте", "ості", "очка", "очкам", "очками", "очках", "очки", "очків", "очкові", "очком", "очку", "очок", "ою",
            "ти", "тись", "тися",
            "у", "ував", "увала", "увати",
            "ь",
            "ці",
            "ю", "юст", "юсь", "юся", "ють", "ються",
            "я", "ям", "ями", "ях",
        };

        // WAT ?
        // к ка кам ками ках ки кою ку
        // ні ню ня ням нями нях

        // endings in unchangable words
        List<string> stable_endings = new List<string>()
        {
            "ер",
            "ск",
        };

        // endings are changing
        private Dictionary<string, string> change_endings =  new Dictionary<string,string>()
        {
            { "аче" , "ак" },
            { "іче" , "ік" },
            { "йовував" , "йов" }, { "йовувала" , "йов" }, { "йовувати" , "йов" },
            { "ьовував" , "ьов" }, { "ьовувала" , "ьов" }, { "ьовувати" , "ьов" },
            { "цьовував" , "ц" }, { "цьовувала" , "ц" }, { "цьовувати" , "ц" },
            { "ядер" , "ядр" }
        };

        // words to skip
        List<string> stable_exclusions = new List<string>()
        {
            "баядер", "беатріче",
            "віче",
            "наче", "неначе",
            "одначе",
            "паче"
        };

        // words to replace
        private Dictionary<string, string> exclusions = new Dictionary<string, string>()
        {
            { "відер" ,"відр" }, 
            { "був" , "бува" }
        };


        public string Stem(string word) 
        {
            // remove punctuation
            word = new string(word.Where(c => char.IsLetter(c)).ToArray());

            // normalize word
            //word = replaceStressedVowels(word);

            // don't change short words
            if (word.Length <= 2 ) return word;

            // check for unchanged exclusions
            if (stable_exclusions.Contains(word)) {
                return word;
            }

            //// check for replace exclusions
            //if (exclusions[word]) {
            //    return exclusions[word];
            //}

            // changing endings
            List<string> keys_change_endings = change_endings.Keys.OrderByDescending(e => e).ToList();
            foreach (string eow in keys_change_endings) 
                if (word.EndsWith(eow)) 
                    return word.Substring(0, word.Length - eow.Length) + change_endings[eow];

            // match for stable endings
            List<string> skip_ends = stable_endings.OrderBy(e => e.Length).ToList();
            foreach (string eow in skip_ends) 
                if (word.EndsWith(eow)) 
                    return word;

            // try simple trim
            List<string> wends = word_ends.OrderBy(e => e.Length).ToList();
            foreach (string eow in wends) 
                if (word.EndsWith(eow)) 
                {
                    string trimmed = word.Substring(0, word.Length - eow.Length);
                    if (trimmed.Length > 2)
                        return trimmed;
                }

            return word;
        }



        /*
         * Replace Ukrainian stressed vowels to unstressed ones
         */
        //private string ReplaceStressedVowels(string word) {
        //    Dictionary<string, string> nagolos = new Dictionary<string,string>
        //    {
        //        { "а́", "а" },
        //        { "е́", "е" },
        //        { "є́", "є" },
        //        { "и́", "и" },
        //        { "і́", "і" },
        //        { "ї́", "ї" },
        //        { "о́", "о" },
        //        { "у́", "у" },
        //        { "ю́", "ю" },
        //        { "я́", "я" }
        //    };

        //    return word.ToLower().collect { nagolos[it] ?: it }.join("")
        //}
    }
}
