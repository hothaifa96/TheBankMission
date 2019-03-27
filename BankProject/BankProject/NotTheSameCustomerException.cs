using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class NotTheSameCustomerException : Exception
    {
        public NotTheSameCustomerException()
        {
        }

        public NotTheSameCustomerException(string message) : base(message)
        {
        }

        public NotTheSameCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotTheSameCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}