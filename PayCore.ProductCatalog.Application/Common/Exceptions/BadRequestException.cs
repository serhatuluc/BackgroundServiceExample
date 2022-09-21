using System;

namespace PayCore.ProductCatalog.Service
{
    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
