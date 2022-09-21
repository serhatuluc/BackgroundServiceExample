using PayCore.ProductCatalog.Service.Dto_Validator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewDto>> GetAll();
        Task<CategoryViewDto> GetById(int id);
        Task Insert(CategoryUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, CategoryUpsertDto dto);
    }
}
