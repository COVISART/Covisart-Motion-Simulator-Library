using System;
using System.Runtime.Serialization;

namespace CovisartMotionSimulatorSDK
{
    [Serializable]
    public class CovisartWarningException : Exception
    {
        public CovisartWarningException()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public CovisartWarningException(string message) : base(message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public CovisartWarningException(string message, Exception innerException) : base(message, innerException)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        protected CovisartWarningException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}