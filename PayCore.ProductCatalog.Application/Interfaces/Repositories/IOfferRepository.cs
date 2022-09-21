using PayCore.ProductCatalog.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Repositories
{
    public interface IOfferRepository:IGenericRepository<Offer>
    {
        Task<IList<Offer>> GetOfferOfUser(int userId);
        Task<IList<Offer>> GetOfferstoUser(int userId);
    }
}
