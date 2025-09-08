using System;

namespace MTBSystem.module.exception
{
    public class LanguageException : Exception
    {
        public LanguageException(string language) : base($"Language {language} is not supported.")
        {
        }
    }

}
