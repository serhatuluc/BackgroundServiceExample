using System;


namespace PayCore.ProductCatalog.Service
{
    public class CredentialException : ApplicationException
    {
        public CredentialException (string message) : base(message)
        {

        }
    }
}
