using NHibernate;
using PayCore.ProductCatalog.Service.Interfaces.Log;
using PayCore.ProductCatalog.Service.Interfaces.Repositories;
using PayCore.ProductCatalog.Data.Entities;


namespace PayCore.ProductCatalog.Repository.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        private readonly ILoggerManager Logger;
        private readonly ISession session;
        private  ITransaction transaction;

        public CategoryRepository(ISession session, ILoggerManager Logger):base(session,Logger)
        {
            this.session = session;
            this.Logger = Logger;
        }
    }
}
