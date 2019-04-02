using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class youHaveReachedTheMaxMinAllowedException : Exception
    {
        public youHaveReachedTheMaxMinAllowedException()
        {
        }

        public youHaveReachedTheMaxMinAllowedException(string message) : base(message)
        {
        }

        public youHaveReachedTheMaxMinAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected youHaveReachedTheMaxMinAllowedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}