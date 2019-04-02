using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class CusomerNotFoundException : Exception
    {
        public CusomerNotFoundException()
        {
        }

        public CusomerNotFoundException(string message) : base(message)
        {
        }

        public CusomerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CusomerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}