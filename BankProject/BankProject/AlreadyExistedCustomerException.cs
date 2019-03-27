using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class AlreadyExistedCustomerException : Exception
    {
        public AlreadyExistedCustomerException()
        {
        }

        public AlreadyExistedCustomerException(string message) : base(message)
        {
        }

        public AlreadyExistedCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyExistedCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}