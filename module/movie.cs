using System;
using MTBSystem.module.exception;

namespace MTBSystem.module
{
    public class movie
    {
        public string MovieID { get; private set; }
        public string MovieName { get; private set; }
        public string ProducerName { get; private set; }
        public string Genre { get; private set; }
        public string Language { get; private set; }
        // string story; // Unused in original logic
        // double Duration; // Unused in original logic


        //constructor for movie registration.
        public movie(string MovieName, string ProducerName, string Genre, string Language)
        {
            //check if language is valid or not.
            if (!isValidLanguage(Language))
            {
                throw new LanguageException(Language);
            }

            Console.WriteLine("Generating ID");
            // Made ID uppercase and ensured 2 chars, handling short inputs
            string id = (MovieName.Length >= 2 ? MovieName.Substring(0, 2) : MovieName).ToUpper() +
                (ProducerName.Length >= 2 ? ProducerName.Substring(0, 2) : ProducerName).ToUpper() +
                (Genre.Length >= 2 ? Genre.Substring(0, 2) : Genre).ToUpper() +
                (Language.Length >= 2 ? Language.Substring(0, 2) : Language).ToUpper();

            this.MovieID = id;
            this.MovieName = MovieName;
            this.ProducerName = ProducerName;
            this.Genre = Genre;
            this.Language = Language;
            Console.WriteLine("\nMovie Registered Successfully");
        }

        //display details of movie.
        public void displayMovie()
        {
            Console.WriteLine($"Details are As - \nName - {this.MovieName}" +
                $"\n Producer - {this.ProducerName}" +
                $"\n Genre - {this.Genre}" +
                $"\n ID - {this.MovieID}");
        }

        //function to check if the language is valid or not.
        private bool isValidLanguage(string language)
        {
            string[] validLanguages = { "English", "Hindi", "bhojpuri", "Marathi" };
            foreach (string lang in validLanguages)
            {
                if (lang.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}