using System;
using System.Runtime.Serialization;

namespace MoodAnalyzer
{
    [Serializable]
    public class MoodAnalyzerException : Exception
    {
        public ExceptionType type;
        //Enumeration
        public enum ExceptionType
        {
            NULL_EXCEPTION,
            EMPTY_EXCEPTION
        }
        //Exception Constructor.
        public MoodAnalyzerException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}