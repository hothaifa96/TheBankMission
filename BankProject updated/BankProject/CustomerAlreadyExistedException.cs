using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class CustomerAlreadyExistedException : Exception
    {
        public CustomerAlreadyExistedException()
        {
        }

        public CustomerAlreadyExistedException(string message) : base(message)
        {
        }

        public CustomerAlreadyExistedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAlreadyExistedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}