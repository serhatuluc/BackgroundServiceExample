using PayCore.ProductCatalog.Service.Dto_Validator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Services
{
    public interface IBrandService 
    {
        Task<IEnumerable<BrandViewDto>> GetAll();
        Task<BrandViewDto> GetById(int id);
        Task Insert(BrandUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, BrandUpsertDto dto);
    }
    
}
