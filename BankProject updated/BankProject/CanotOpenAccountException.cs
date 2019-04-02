using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class CanotOpenAccountException : Exception
    {
        public CanotOpenAccountException()
        {
        }

        public CanotOpenAccountException(string message) : base(message)
        {
        }

        public CanotOpenAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CanotOpenAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}