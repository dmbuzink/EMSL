using System;

namespace EMSL.Language.Models
{
    public class EmslException : Exception
    {
        public EmslException(string message) : base(message)
        {}
    }

    public class EmslParserException : EmslException
    {
        public EmslParserException(string? message) : base(message ?? "The given input is not valid EMSL")
        {
        }
    }
}