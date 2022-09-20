using PayCore.ProductCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace PayCore.ProductCatalog.UnitTest
{
    public static class Datas
    {
        public static IEnumerable<Account> GetAccountsData()
        {
            var result = new List<Account>
            {
                new Account {Id = 1, UserName = "Admin", Password = "Admin123"},

            }.AsQueryable();

            return result;
        }

       
    }
}

