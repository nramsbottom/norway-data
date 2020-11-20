using System;

namespace Norway.Data.PostalCodeLookupApp
{
    internal class PafException : Exception
    {
        public PafException(string message) : base(message)
        {
        }

        public PafException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
