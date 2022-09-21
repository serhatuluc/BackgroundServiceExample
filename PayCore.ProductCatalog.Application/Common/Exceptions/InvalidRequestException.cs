using System;


namespace PayCore.ProductCatalog.Service.Common.Exceptions
{
    public class InvalidRequestException : ApplicationException
    {
        public InvalidRequestException(string name, object key) : base($"There are {name}s with id ({key}).")
        {

        }
    }
}
