using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class AlreadyExistedAcountException : Exception
    {
        public AlreadyExistedAcountException()
        {
        }

        public AlreadyExistedAcountException(string message) : base(message)
        {
        }

        public AlreadyExistedAcountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyExistedAcountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}