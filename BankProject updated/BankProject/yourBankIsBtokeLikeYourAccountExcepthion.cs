using System;
using System.Runtime.Serialization;

namespace BankProject
{
    [Serializable]
    internal class yourBankIsBtokeLikeYourAccountExcepthion : Exception
    {
        public yourBankIsBtokeLikeYourAccountExcepthion()
        {
        }

        public yourBankIsBtokeLikeYourAccountExcepthion(string message) : base(message)
        {
        }

        public yourBankIsBtokeLikeYourAccountExcepthion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected yourBankIsBtokeLikeYourAccountExcepthion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}