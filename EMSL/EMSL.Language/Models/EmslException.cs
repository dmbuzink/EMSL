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
    
    public class EmslUnsupportedResourceTypeException : EmslException
    {
        public EmslUnsupportedResourceTypeException(string value) : base($"Unsupported resource type value: {value}")
        {
        }
    }
    
    public class EmslUndefinedSourceException : EmslException
    {
        public EmslUndefinedSourceException(string sourceCsp) : base($"Undefined source CSP: {sourceCsp}")
        {
        }
    }
    
    public class EmslUndefinedTargetException : EmslException
    {
        public EmslUndefinedTargetException(string targetCsp) : base($"Undefined source CSP: {targetCsp}")
        {
        }
    }
    
    public class EmslUndefinedResourceException : EmslException
    {
        public EmslUndefinedResourceException(string resource) : base($"Undefined resource: {resource}")
        {
        }
    }
}