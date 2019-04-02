using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class CustomerIdAlreadyExistedException : Exception
    {
        public CustomerIdAlreadyExistedException()
        {
        }

        public CustomerIdAlreadyExistedException(string message) : base(message)
        {
        }

        public CustomerIdAlreadyExistedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerIdAlreadyExistedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}